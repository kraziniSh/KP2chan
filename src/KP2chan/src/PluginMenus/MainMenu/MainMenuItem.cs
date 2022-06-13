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
        internal static ToolStripMenuItem Create() {
            var mainMenuItem = new ToolStripMenuItem(
                text: Resources.KP2chan.pluginName
                // TODO image:
                );
            var enableAllButton = MainEnableButton.Create();
            var disableAllButton = MainDisableButton.Create();

            mainMenuItem.DropDownItems.Add(enableAllButton);
            mainMenuItem.DropDownItems.Add(disableAllButton);

            return mainMenuItem;
        }

        internal static void Terminate() {
            MainEnableButton.Terminate();
            MainDisableButton.Terminate();
        }
    }
}
