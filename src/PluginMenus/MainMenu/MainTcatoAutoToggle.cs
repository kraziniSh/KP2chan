/*
KP2chan; 2CTcatoO empowered.
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
    internal static class MainTcatoAutoEnableToggle {
        internal static TcatoAutoEnabler tcatoAutoEnabler;

        private static ToolStripMenuItem toggle;

        internal static ToolStripMenuItem Create() {
            var pluginHost = KP2chanExt.pluginHost;

            toggle = new ToolStripMenuItem(
                text: Properties.Strings.tcatoAutoEnable,
                image: null,
                onClick: TcatoAutoEnablerToggle_Click
                ) {
                Checked = ATAutoEnabler.Enabled
            };

            pluginHost.MainWindow.FileOpened += MainTcatoAutoEnableToggle_FileOpened;
            pluginHost.MainWindow.FileClosingPre += MainTcatoAutoEnableToggle_FileClosingPre;

            return toggle;
        }

        private static void MainTcatoAutoEnableToggle_FileOpened(object sender, FileOpenedEventArgs e) {
            tcatoAutoEnabler = new TcatoAutoEnabler();
        }

        private static void MainTcatoAutoEnableToggle_FileClosingPre(object sender, FileClosingEventArgs e) {
            tcatoAutoEnabler.Terminate();
            tcatoAutoEnabler = null;
        }

        private static void TcatoAutoEnablerToggle_Click(object sender, EventArgs e) {
            TcatoAutoEnabler.Enabled = !TcatoAutoEnabler.Enabled;

            toggle.Checked = TcatoAutoEnabler.Enabled;
        }

        internal static void Terminate() {
            var pluginHost = KP2chanExt.pluginHost;

            if (tcatoAutoEnabler != null && pluginHost.Database.IsOpen) {
                tcatoAutoEnabler.Terminate();
                tcatoAutoEnabler = null;
            }

            pluginHost.MainWindow.FileOpened -= MainTcatoAutoEnableToggle_FileOpened;
            pluginHost.MainWindow.FileClosingPre -= MainTcatoAutoEnableToggle_FileClosingPre;

            toggle.Click -= TcatoAutoEnablerToggle_Click;
            toggle.Dispose();
            toggle = null;
        }
    }
}
