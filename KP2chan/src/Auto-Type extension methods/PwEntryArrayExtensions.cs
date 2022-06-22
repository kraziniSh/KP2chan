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
    ///   Extension methods that allow control of Auto-Type and TCATO on arrays
    ///   of password entries. Wraps around <see cref="PwEntryExtensions"/>
    ///   methods.
    /// </summary>
    internal static class PwEntryArrayExtensions {
        /// <summary>
        ///   <para>
        ///     Enables/disables Auto-Type this array of password entries.
        ///     They can be obtained by methods such as
        ///     <see cref="KeePass.Plugins.IPluginHost.MainWindow"/>
        ///     <c>.GetSelectedEntries()</c>.
        ///   </para>
        ///   <para>
        ///     This method doesn't automatically enable TCATO.
        ///   </para>
        /// </summary>
        /// <param name="entries">
        ///   <para>
        ///     An array of <see cref="PwEntry"/> (password entries). Can be obtained by
        ///     methods such as
        ///     <see cref="KeePass.Plugins.IPluginHost.MainWindow"/>
        ///     <c>.GetSelectedEntries()</c>.
        ///   </para>
        ///   <para>
        ///     Password entry arrays are different from <see cref="PwGroup"/>s:
        ///     password groups.
        ///   </para>
        /// </param>
        /// <param name="state">
        ///   <para>Whether to allow Auto-Type for those entries.</para>
        ///   <para>Doesn't affect TCATO.</para>
        /// </param>
        internal static void SetAutoType(this PwEntry[] entries, bool state) {
            foreach (PwEntry entry in entries) {
                entry.SetAutoType(state);
            }
        }

        /// <summary>
        ///   <para>
        ///     Enables/disables TCATO this array of password entries. They can
        ///     be obtained by methods such as
        ///     <see cref="KeePass.Plugins.IPluginHost.MainWindow"/>
        ///     <c>.GetSelectedEntries()</c>.
        ///   </para>
        ///   <para>
        ///     Automatically enables Auto-Type on them if <c>true</c>.
        ///   </para>
        /// </summary>
        /// <param name="entries">
        ///   <para>
        ///     An array of <see cref="PwEntry"/> (password entries). Can be obtained by
        ///     methods such as
        ///     <see cref="KeePass.Plugins.IPluginHost.MainWindow"/>
        ///     <c>.GetSelectedEntries()</c>.
        ///   </para>
        ///   <para>
        ///     Password entry arrays are different from <see cref="PwGroup"/>s:
        ///     password groups.
        ///   </para>
        /// </param>
        /// <param name="state">
        ///   Whether to enable TCATO for those entries. Automatically enables
        ///   Auto-Type on them if <c>true</c>.
        /// </param>
        internal static void SetTcato(this PwEntry[] entries, bool state) {
            foreach (PwEntry entry in entries) {
                entry.SetTcato(state);
            }
        }
    }
}
