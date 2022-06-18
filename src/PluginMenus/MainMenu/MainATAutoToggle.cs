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

using System;
using System.Windows.Forms;

namespace KP2chan {
    // FIXME Not automatically enabling on creation.
    internal static class MainATAutoEnableToggle {
        internal static ATAutoEnabler atAutoEnabler;

        private static ToolStripMenuItem toggle;

        internal static ToolStripMenuItem Create() {
            toggle = new ToolStripMenuItem(
                text: Properties.Strings.atAutoEnable,
                image: null,
                onClick: ATAutoEnablerToggle_Click
                ) {
                Checked = true
            };

            atAutoEnabler = new ATAutoEnabler();

            return toggle;
        }

        private static void ATAutoEnablerToggle_Click(object sender, EventArgs e) {
            atAutoEnabler.Enabled = !atAutoEnabler.Enabled;

            toggle.Checked = atAutoEnabler.Enabled;
        }

        internal static void Terminate() {
            atAutoEnabler.Terminate();
            atAutoEnabler = null;

            toggle.Click -= ATAutoEnablerToggle_Click;
            toggle.Dispose();
            toggle = null;
        }
    }
}
