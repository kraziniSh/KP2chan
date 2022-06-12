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

using KeePass.Plugins;
using KeePassLib;
using KeePassLib.Collections;
using System;
using System.Windows.Forms;

namespace KP2chan {
    [System.ComponentModel.DesignerCategory(null)]
    internal sealed class DisableAllButton : ToolStripItem {
        private static IPluginHost pluginHost;

        internal DisableAllButton() {
            pluginHost = KP2chanExt.pluginHost;

            Text = Resources.KP2chan.mainDisableAllButton;

            Click += DisableAllButton_Click;
        }

        private void DisableAllButton_Click(object sender, EventArgs e) {
            PwGroup rootGroup = pluginHost.Database.RootGroup;
            if (rootGroup == null) {
                pluginHost.MainWindow.SetStatusEx(Resources.KP2chan.noDatabaseOpened);
            }

            rootGroup.Entries.SetAutoTypeObfuscationOption(AutoTypeObfuscationOptions.None);

            pluginHost.MainWindow.SetStatusEx(Resources.KP2chan.tcatoDisabledAll);
        }

        /// <summary>
        /// Cleans this up. First unsubscribes from its (private) events, then
        /// disposes itself.
        /// </summary>
        internal void Delete() {
            Click -= DisableAllButton_Click;
            Dispose();
        }
    }
}
