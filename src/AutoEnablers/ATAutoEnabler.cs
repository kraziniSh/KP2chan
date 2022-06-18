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

namespace KP2chan {
    internal sealed class ATAutoEnabler {
        internal const string CONFIG_AUTO_AT_ENABLED_STR_ID = "KP2chan_ATauto";

        /// <summary>
        ///     Gets whether auto-activation of Auto-Type on new entries is
        ///     enabled. On by default.
        ///     Can be <c>false</c> if the <c>CustomConfig</c> setting could not be
        ///     found; it's safer this way.
        /// </summary>
        internal bool Enabled {
            get { return KP2chanExt.pluginHost.CustomConfig.GetBool(CONFIG_AUTO_AT_ENABLED_STR_ID, false); }
            set { KP2chanExt.pluginHost.CustomConfig.SetBool(CONFIG_AUTO_AT_ENABLED_STR_ID, value); }
        }

        internal ATAutoEnabler() {
            var pluginHost = KP2chanExt.pluginHost;

            pluginHost.MainWindow.DefaultEntryAction += ATAutoEnabler_EntryCreated;
        }

        private void ATAutoEnabler_EntryCreated(object sender, KeePass.Forms.CancelEntryEventArgs e) {
            var entry = e.Entry;

            if (!Enabled) {
                entry.SetAutoType(false);
            }
        }

        internal void Terminate() {
            var pluginHost = KP2chanExt.pluginHost;

            pluginHost.MainWindow.DefaultEntryAction -= ATAutoEnabler_EntryCreated;
        }
    }
}
