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
    internal static class MainTcatoAutoEnableToggle {
        internal static TcatoAutoEnabler tcatoAutoEnabler;

        private static ToolStripMenuItem toggle;

        internal static ToolStripMenuItem Create() {
            toggle = new ToolStripMenuItem(
                text: Properties.Strings.tcatoAutoEnable,
                image: null,
                onClick: TcatoAutoEnablerToggle_Click
                );

            tcatoAutoEnabler = new TcatoAutoEnabler();

            return toggle;
        }

        private static void TcatoAutoEnablerToggle_Click(object sender, EventArgs e) {
            tcatoAutoEnabler.Enabled = !tcatoAutoEnabler.Enabled;

            toggle.Checked = tcatoAutoEnabler.Enabled;
        }

        internal static void Terminate() {
            tcatoAutoEnabler.Terminate();
            tcatoAutoEnabler = null;

            toggle.Click -= TcatoAutoEnablerToggle_Click;
            toggle.Dispose();
            toggle = null;
        }
    }
}
