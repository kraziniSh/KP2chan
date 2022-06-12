﻿/*
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
    [System.ComponentModel.DesignerCategory(null)]
    internal sealed class MainMenuItem : ToolStripMenuItem {
        private readonly EnableAllButton enableAll;
        private readonly DisableAllButton disableAll;

        internal MainMenuItem() {
            var host = KP2chanExt.pluginHost;

            Text = Resources.KP2chan.pluginName;
            // TODO Image

            enableAll = new EnableAllButton();
            disableAll = new DisableAllButton();

            DropDownItems.Add(enableAll);
            DropDownItems.Add(disableAll);
        }

        internal void Delete() {
            enableAll.Delete();
            disableAll.Delete();

            DropDownItems.Clear();

            Dispose();
        }
    }
}