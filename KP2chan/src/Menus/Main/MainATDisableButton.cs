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

using System;
using System.Windows.Forms;

namespace KP2chan {
    internal static class MainATDisableButton {
        private static ToolStripMenuItem button;

        internal static ToolStripMenuItem Create() {
            var pluginHost = KP2chanExt.pluginHost;

            button = new ToolStripMenuItem(
                text: Properties.Strings.allATDisable,
                image: null,
                onClick: Button_Click
                ) {
                Enabled = false
            };

            pluginHost.MainWindow.FileOpened += EnableButton;
            pluginHost.MainWindow.FileClosed += DisableButton;

            return button;
        }

        private static void Button_Click(object sender, EventArgs e) {
            var pluginHost = KP2chanExt.pluginHost;

            pluginHost.Database.RootGroup.SetAutoType(false);

            pluginHost.MainWindow.SetStatusEx(Properties.Strings.allATDisabled);
        }

        private static void EnableButton(object sender, KeePass.Forms.FileOpenedEventArgs e) {
            button.Enabled = true;
        }

        private static void DisableButton(object sender, KeePass.Forms.FileClosedEventArgs e) {
            button.Enabled = false;
        }

        internal static void Terminate() {
            var pluginHost = KP2chanExt.pluginHost;

            button.Click -= Button_Click;
            pluginHost.MainWindow.FileOpened -= EnableButton;
            pluginHost.MainWindow.FileClosed -= DisableButton;
            button.Dispose();
            button = null;
        }
    }
}
