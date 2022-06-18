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
using System.Globalization;
using System.Windows.Forms;

namespace KP2chan {
    public sealed class KP2chanExt : Plugin {
        internal static IPluginHost pluginHost;

        private ToolStripItemCollection toolsMenu;

        private ToolStripSeparator separator;
        private ToolStripMenuItem pluginEntryMenu;
        private ToolStripMenuItem pluginGroupMenu;
        private ToolStripMenuItem pluginMainMenu;

        public override string UpdateUrl {
            get {
                return "https://l9cro1xx.github.io/keepass/update";
            }
        }

        // TODO SmallIcon

        /// <summary>
        /// The Initialize function is called by KeePass when
        /// you should initialize your plugin (create menu items, etc.).
        /// </summary>
        /// <param name="initializingHost">
        /// Plugin host interface. By using this
        /// interface, you can access the KeePass main window and the
        /// currently opened database.
        /// </param>
        /// <returns>
        /// You must return true in order to signal
        /// successful initialization. If you return false,
        /// KeePass unloads your plugin (without calling the
        /// Terminate function of your plugin).
        /// </returns>
        public override bool Initialize(IPluginHost initializingHost) {
            if (initializingHost != null) pluginHost = initializingHost;
            else return false;

            // var installedUICulture = CultureInfo.InstalledUICulture;
            // CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InstalledUICulture;

            toolsMenu = pluginHost.MainWindow.ToolsMenu.DropDownItems;

            separator = new ToolStripSeparator();
            pluginEntryMenu = EntryMenuItem.Initialize();
            pluginGroupMenu = GroupMenuItem.Initialize();
            pluginMainMenu = MainMenuItem.Initialize();

            toolsMenu.Add(separator);

            return true;
        }

        /// <summary>
        /// Get a menu item of the plugin. See
        /// https://keepass.info/help/v2_dev/plg_index.html#co_menuitem
        /// </summary>
        /// <param name="pluginMenuType">
        /// Type of the menu that the plugin should return an item for.
        /// </param>
        public override ToolStripMenuItem GetMenuItem(PluginMenuType pluginMenuType) {
            switch (pluginMenuType) {
                case PluginMenuType.Entry:
                    return pluginEntryMenu;
                case PluginMenuType.Group:
                    return pluginGroupMenu;
                case PluginMenuType.Main:
                    return pluginMainMenu;
                default:
                    return null;
            }
        }

        /// <summary>
        /// The Terminate method is called by KeePass when
        /// you should free all resources, close files/streams,
        /// remove event handlers, etc.
        /// </summary>
        public override void Terminate() {
            EntryMenuItem.Terminate();
            GroupMenuItem.Terminate();
            MainMenuItem.Terminate();

            pluginEntryMenu = null;
            pluginGroupMenu = null;
            pluginMainMenu = null;

            separator.Dispose();

            toolsMenu.Clear();
        }
    }
}
