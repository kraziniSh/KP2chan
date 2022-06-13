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

using KeePassLib.Collections;
using System;
using System.Windows.Forms;

namespace KP2chan {
    internal static class MainEnableButton {
        private static ToolStripMenuItem enableButton;

        internal static ToolStripMenuItem Create() {
            enableButton = new ToolStripMenuItem(
                text: Properties.Strings.mainEnableButton,
                image: null,
                onClick: MainEnableButton_Click
                );

            enableButton.DropDownOpening += MainEnableButton_DropDownOpening;

            return enableButton;
        }

        private static void MainEnableButton_Click(object sender, EventArgs e) {
            var pluginHost = KP2chanExt.pluginHost;

            pluginHost.Database.RootGroup.SetAutoTypeObfuscationOptions(AutoTypeObfuscationOptions.UseClipboard);

            pluginHost.MainWindow.SetStatusEx(Properties.Strings.mainEnabled);
        }

        private static void MainEnableButton_DropDownOpening(object sender, EventArgs e) {
            enableButton.Enabled = KP2chanExt.pluginHost.Database.IsOpen;
        }

        internal static void Terminate() {
            enableButton.Click -= MainEnableButton_Click;
            enableButton.DropDownOpening -= MainEnableButton_DropDownOpening;
            enableButton.Dispose();
        }
    }
}
