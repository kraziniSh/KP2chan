/*
KP2chan; 2CATO empowered.
    Copyright (C) 2022  1A3CROIXX

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.

*/

using KeePass.Forms;
using System;
using System.Windows.Forms;

namespace KP2chan {
    internal static class MainATAutoEnableToggle {
        internal static ATAutoEnabler atAutoEnabler;

        private static ToolStripMenuItem toggle;

        internal static ToolStripMenuItem Create() {
            var pluginHost = KP2chanExt.pluginHost;

            toggle = new ToolStripMenuItem(
                text: Properties.Strings.atAutoEnable,
                image: null,
                onClick: ATAutoEnablerToggle_Click
                ) {
                Checked = ATAutoEnabler.Enabled
            };

            pluginHost.MainWindow.FileOpened += MainATAutoEnableToggle_FileOpened;
            pluginHost.MainWindow.FileClosingPre += MainATAutoEnableToggle_FileClosingPre;

            return toggle;
        }

        private static void MainATAutoEnableToggle_FileOpened(object sender, FileOpenedEventArgs e) {
            atAutoEnabler = new ATAutoEnabler();
        }

        private static void MainATAutoEnableToggle_FileClosingPre(object sender, FileClosingEventArgs e) {
            atAutoEnabler.Terminate();
            atAutoEnabler = null;
        }

        private static void ATAutoEnablerToggle_Click(object sender, EventArgs e) {
            ATAutoEnabler.Enabled = !ATAutoEnabler.Enabled;

            toggle.Checked = ATAutoEnabler.Enabled;
        }

        internal static void Terminate() {
            var pluginHost = KP2chanExt.pluginHost;

            if (atAutoEnabler != null && pluginHost.Database.IsOpen) {
                atAutoEnabler.Terminate();
                atAutoEnabler = null;
            }

            pluginHost.MainWindow.FileOpened -= MainATAutoEnableToggle_FileOpened;
            pluginHost.MainWindow.FileClosingPre -= MainATAutoEnableToggle_FileClosingPre;

            toggle.Click -= ATAutoEnablerToggle_Click;
            toggle.Dispose();
            toggle = null;
        }
    }
}
