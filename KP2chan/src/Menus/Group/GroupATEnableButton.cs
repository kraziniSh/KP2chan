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
    internal static class GroupATEnableButton {
        private static ToolStripMenuItem button;

        internal static ToolStripMenuItem Create() {
            button = new ToolStripMenuItem(
                text: Properties.Strings.groupATEnable,
                image: null,
                onClick: Button_Click
                );

            return button;
        }

        private static void Button_Click(object sender, EventArgs e) {
            var pluginHost = KP2chanExt.pluginHost;

            var selectedGroup = pluginHost.MainWindow.GetSelectedGroup();

            selectedGroup.SetAutoType(true);

            if (selectedGroup == pluginHost.Database.RootGroup) {
                pluginHost.MainWindow.SetStatusEx(Properties.Strings.allATEnabled);
            } else {
                pluginHost.MainWindow.SetStatusEx(
                string.Format(Properties.Strings.groupATEnabled, selectedGroup.Name)
                );
            }
        }

        internal static void Terminate() {
            button.Click -= Button_Click;
            button.Dispose();
            button = null;
        }
    }
}
