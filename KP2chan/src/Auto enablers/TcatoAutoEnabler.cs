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

using KeePassLib;
using KeePassLib.Collections;

namespace KP2chan {
    // FIXME Unable to implement auto-activator yet.
    internal sealed class TcatoAutoEnabler {
        internal const string CONFIG_AUTO_TCTcatoO_ENABLED_STR_ID = "KP2chan_TcatoAuto";

        /// <summary>
        ///     Gets whether auto-activation of TCATO on new entries is
        ///     enabled. Off by default.
        ///     Can be <c>false</c> if the <c>CustomConfig</c> setting could not be
        ///     found; it's safer this way.
        /// </summary>
        internal static bool Enabled {
            get { return KP2chanExt.pluginHost.CustomConfig.GetBool(CONFIG_AUTO_TCTcatoO_ENABLED_STR_ID, false); }
            set { KP2chanExt.pluginHost.CustomConfig.SetBool(CONFIG_AUTO_TCTcatoO_ENABLED_STR_ID, value); }
        }

        internal TcatoAutoEnabler() {
            var pluginHost = KP2chanExt.pluginHost;

            pluginHost.Database.RootGroup.Touched += TcatoAutoEnabler_DatabaseTouched;
        }

        private void TcatoAutoEnabler_DatabaseTouched(object sender, ObjectTouchedEventArgs e) {
            var touchedObject = e.Object;

            if (touchedObject.GetType() == typeof(PwEntry)) {
                PwEntry touchedEntry = (PwEntry)touchedObject;

                if (Enabled) {
                    touchedEntry.SetAutoType(true);
                    touchedEntry.SetAutoTypeObfuscationOptions(AutoTypeObfuscationOptions.UseClipboard);
                } else {
                    touchedEntry.SetAutoTypeObfuscationOptions(AutoTypeObfuscationOptions.None);
                }
            }
        }

        internal void Terminate() {
            var pluginHost = KP2chanExt.pluginHost;

            pluginHost.Database.RootGroup.Touched -= TcatoAutoEnabler_DatabaseTouched;
        }
    }
}
