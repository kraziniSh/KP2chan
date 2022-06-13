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

using System.Windows.Forms;

namespace KP2chan {
    internal static class MainMenuItem {
        private static ToolStripMenuItem menuItem;
        internal static ToolStripMenuItem Create() {
            var pluginHost = KP2chanExt.pluginHost;

            menuItem = new ToolStripMenuItem(
                text: Properties.Strings.pluginName
                // TODO image:
                ) {
                Enabled = false
            };

            menuItem.DropDownItems.AddRange(new[] {
                MainEnableATButton.Create(),
                MainDisableATButton.Create(),
                MainEnableTcatoButton.Create(),
                MainDisableTcatoButton.Create()
            });

            pluginHost.MainWindow.FileOpened += EnableMenuItem;
            pluginHost.MainWindow.FileClosed += DisableMenuItem;

            return menuItem;
        }

        private static void EnableMenuItem(object sender, KeePass.Forms.FileOpenedEventArgs e) {
            menuItem.Enabled = true;
        }

        private static void DisableMenuItem(object sender, KeePass.Forms.FileClosedEventArgs e) {
            menuItem.Enabled = false;
        }

        internal static void Terminate() {
            var pluginHost = KP2chanExt.pluginHost;

            MainEnableATButton.Terminate();
            MainDisableATButton.Terminate();
            MainEnableTcatoButton.Terminate();
            MainDisableTcatoButton.Terminate();
            pluginHost.MainWindow.FileOpened -= EnableMenuItem;
            pluginHost.MainWindow.FileClosed -= DisableMenuItem;
        }
    }
}
