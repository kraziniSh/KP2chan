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
    internal static class PwEntryExtensions {
        internal static AutoTypeObfuscationOptions GetAutoTypeObfuscationOptions(this PwEntry entry) {
            return entry.AutoType.ObfuscationOptions;
        }

        internal static void SetAutoType(this PwEntry entry, bool enabled) {
            var pluginHost = KP2chanExt.pluginHost;

            entry.Touch(bModified: false, bTouchParents: true);

            if (entry.GetAutoTypeEnabled() != enabled) {
                entry.AutoType.Enabled = enabled;

                entry.Touch(bModified: true, bTouchParents: true);
            }

            pluginHost.Database.Modified = true;
        }

        internal static void SetAutoTypeObfuscationOptions(this PwEntry entry, AutoTypeObfuscationOptions option) {
            var pluginHost = KP2chanExt.pluginHost;

            entry.Touch(bModified: false, bTouchParents: true);

            if (option == AutoTypeObfuscationOptions.UseClipboard) {
                entry.SetAutoType(true);
            }

            if (entry.GetAutoTypeObfuscationOptions() != option) {
                entry.AutoType.ObfuscationOptions = option;

                entry.Touch(bModified: true, bTouchParents: true);
            }

            pluginHost.Database.Modified = true;
        }
    }
}
