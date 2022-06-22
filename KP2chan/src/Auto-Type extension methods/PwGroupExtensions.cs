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

namespace KP2chan {
    /// <summary>
    ///   Extension methods that allow control of Auto-Type and TCATO on groups
    ///   of password entries. Wraps around <see cref="PwEntryExtensions"/>
    ///   methods.
    /// </summary>
    internal static class PwGroupExtensions {
        /// <summary>
        ///   <para>
        ///     Enables/disables Auto-Type for this group of password entries.
        ///   </para>
        ///   <para>
        ///     This method doesn't automatically enable TCATO.
        ///   </para>
        /// </summary>
        /// <param name="group">
        ///   <para>
        ///     A <see cref="PwGroup"/>: group of password entries.
        ///   </para>
        ///   <para>
        ///     Groups are different from <see cref="PwEntry"/>[]: arrays of password
        ///     entries.
        ///   </para>
        /// </param>
        /// <param name="state">
        ///   <para>
        ///     Whether to allow Auto-Type for entries of this group.
        ///   </para>
        ///   <para>Doesn't affect TCATO.</para>
        /// </param>
        internal static void SetAutoType(this PwGroup group, bool state) {
            foreach (PwEntry entry in group.GetEntries(bIncludeSubGroupEntries: true)) {
                entry.SetAutoType(state);
            }
        }

        /// <summary>
        ///   <para>
        ///     Enables/disables TCATO for this group of password entries.
        ///   </para>
        ///   <para>
        ///     Automatically enables Auto-Type on them if <c>true</c>.
        ///   </para>
        /// </summary>
        /// <param name="group">
        ///   <para>
        ///     A <see cref="PwGroup"/>: group of password entries.
        ///   </para>
        ///   <para>
        ///     Groups are different from <see cref="PwEntry"/>[]: arrays of password
        ///     entries.
        ///   </para>
        /// </param>
        /// <param name="state">
        ///   Whether to enable TCATO for entries of this group. Automatically enables
        ///   Auto-Type on them if <c>true</c>.
        /// </param>
        internal static void SetTcato(this PwGroup group, bool state) {
            foreach (PwEntry entry in group.GetEntries(bIncludeSubGroupEntries: true)) {
                entry.SetTcato(state);
            }
        }
    }
}
