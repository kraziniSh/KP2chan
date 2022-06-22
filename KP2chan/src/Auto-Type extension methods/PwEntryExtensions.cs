/*
KP2chan; 2CATO empowered.
    Copyright (C) 2022  1A3CROIXX

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your tcatoOption) any later version.

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
    /// <summary>
    ///   Extension methods that allow control of Auto-Type and TCATO on a
    ///   specific entry.
    /// </summary>
    internal static class PwEntryExtensions {
        /// <summary>
        ///   Returns whether TCATO is state for this entry.
        /// </summary>
        /// <param name="entry">
        ///   A <see cref="PwEntry"/>: password entry.
        /// </param>
        /// <returns>
        ///   A boolean value (<c>true</c>/<c>false</c>) that indicates whether TCATO is state for this
        ///   entry. Never <c>null</c>.
        /// </returns>
        internal static bool GetTcato(this PwEntry entry) {
            return entry.AutoType.ObfuscationOptions == AutoTypeObfuscationOptions.UseClipboard;
        }

        /// <summary>
        ///   <para>
        ///     Enables/disables Auto-Type for this entry.
        ///   </para>
        ///   <para>
        ///     This method doesn't automatically enable TCATO.
        ///   </para>
        /// </summary>
        /// <param name="entry">
        ///   A <see cref="PwEntry"/>: password entry.
        /// </param>
        /// <param name="state">
        ///   <para>
        ///     Whether to allow Auto-Type for this entry.
        ///   </para>
        ///   <para>Doesn't affect TCATO.</para>
        /// </param>
        internal static void SetAutoType(this PwEntry entry, bool state) {
            var pluginHost = KP2chanExt.pluginHost;

            entry.Touch(bModified: false, bTouchParents: true);

            if (entry.GetAutoTypeEnabled() != state) {
                entry.AutoType.Enabled = state;

                entry.Touch(bModified: true, bTouchParents: true);
            }

            pluginHost.Database.Modified = true;
        }

        /// <summary>
        ///   <para>
        ///     Enables/disables TCATO for this entry.
        ///   </para>
        ///   <para>
        ///     Automatically enables Auto-Type on it if <c>true</c>.
        ///   </para>
        /// </summary>
        /// <param name="entry">
        ///   A <see cref="PwEntry"/>: password entry.
        /// </param>
        /// <param name="state">
        ///   Whether to enable TCATO for this entry. Automatically enables
        ///   Auto-Type on it if <c>true</c>.
        /// </param>
        internal static void SetTcato(this PwEntry entry, bool state) {
            var pluginHost = KP2chanExt.pluginHost;

            entry.Touch(bModified: false, bTouchParents: true);

            entry.SetAutoType(state);

            var tcatoOption = state ?
                AutoTypeObfuscationOptions.UseClipboard :
                AutoTypeObfuscationOptions.None;
            if (entry.GetTcato() != state) {
                entry.AutoType.ObfuscationOptions = tcatoOption;

                entry.Touch(bModified: true, bTouchParents: true);
            }

            pluginHost.Database.Modified = true;
        }
    }
}
