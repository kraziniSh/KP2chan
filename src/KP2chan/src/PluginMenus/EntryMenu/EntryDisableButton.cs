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
using KeePassLib;
using KeePassLib.Collections;

namespace KP2chan {
    internal static class EntryDisableButton {
        private static ToolStripMenuItem disableButton;
        internal static ToolStripMenuItem Create() {
            disableButton = new ToolStripMenuItem(
                text: Resources.KP2chan.entryDisableButton,
                image: null,
                onClick: EntryDisableButton_Click
                );

            return disableButton;
        }

        private static void EntryDisableButton_Click(object sender, EventArgs e) {
            var pluginHost = KP2chanExt.pluginHost;

            var selectedEntries = pluginHost.MainWindow.GetSelectedEntries();
            selectedEntries.SetAutoTypeObfuscationOptions(AutoTypeObfuscationOptions.None);

            var selectedEntriesCount = selectedEntries.Length;
            if (selectedEntriesCount == 1) {
                var entryTitle = selectedEntries[0].Strings.ReadSafeEx(PwDefs.TitleField);
                pluginHost.MainWindow.SetStatusEx(
                    string.Format(Resources.KP2chan.entryDisabledForSingle, entryTitle)
                    );
            } else {
                pluginHost.MainWindow.SetStatusEx(
                    string.Format(Resources.KP2chan.entryDisabledForMultiple, selectedEntriesCount)
                    );
            }
        }

        internal static void Terminate() {
            disableButton.Click -= EntryDisableButton_Click;
            disableButton.Dispose();
        }
    }
}
