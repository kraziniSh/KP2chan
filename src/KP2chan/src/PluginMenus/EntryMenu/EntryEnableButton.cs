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
    internal static class EntryEnableButton {
        private static ToolStripMenuItem enableButton;
        internal static ToolStripMenuItem Create() {
            enableButton = new ToolStripMenuItem(
                text: Resources.KP2chan.entryEnableButton,
                image: null,
                onClick: EntryEnableButton_Click
                );

            return enableButton;
        }

        private static void EntryEnableButton_Click(object sender, EventArgs e) {
            var pluginHost = KP2chanExt.pluginHost;

            var selectedEntries = pluginHost.MainWindow.GetSelectedEntries();
            selectedEntries.SetAutoTypeObfuscationOptions(AutoTypeObfuscationOptions.UseClipboard);

            var selectedEntriesCount = selectedEntries.Length;
            if (selectedEntriesCount == 1) {
                var entryTitle = selectedEntries[0].Strings.ReadSafeEx(PwDefs.TitleField);
                pluginHost.MainWindow.SetStatusEx(
                    string.Format(Resources.KP2chan.entryEnabledForSingle, entryTitle)
                    );
            } else {
                pluginHost.MainWindow.SetStatusEx(
                    string.Format(Resources.KP2chan.entryEnabledForMultiple, selectedEntriesCount)
                    );
            }
        }

        internal static void Terminate() {
            enableButton.Click -= EntryEnableButton_Click;
            enableButton.Dispose();
        }
    }
}
