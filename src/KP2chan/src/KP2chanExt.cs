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
using System.Drawing;
using System.Windows.Forms;

namespace KP2chan {
    public sealed class KP2chanExt : Plugin {
        internal static IPluginHost pluginHost;

        private readonly ToolStripItemCollection toolsMenu = pluginHost.MainWindow.ToolsMenu.DropDownItems;
        private ToolStripSeparator separator;
        private MainMenuItem pluginMainMenu;
        private GroupMenuItem pluginGroupMenu;
        private EntryMenuItem pluginEntryMenu;

        public override string UpdateUrl =>
            "https://github.com/l9cro1xx/kp2chan/update.txt";

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

            separator = new ToolStripSeparator();
            pluginMainMenu = new MainMenuItem();
            pluginGroupMenu = new GroupMenuItem();
            pluginEntryMenu = new EntryMenuItem();

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
                case PluginMenuType.Main:
                    return pluginMainMenu;
                case PluginMenuType.Group:
                    return pluginGroupMenu;
                case PluginMenuType.Entry:
                    return pluginEntryMenu;
                case PluginMenuType.Tray:
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
            pluginMainMenu.Delete();
            pluginGroupMenu.Delete();
            pluginEntryMenu.Delete();

            separator.Dispose();

            toolsMenu.Clear();
        }
    }
}
