using KeePassLib;
using KeePassLib.Collections;

namespace KP2chan {
    internal static class PwGroupExtensions {
        internal static void SetAutoType(this PwGroup group, bool enabled) {
            foreach (PwEntry entry in group.GetEntries(bIncludeSubGroupEntries: true)) {
                entry.SetAutoType(enabled);
            }
        }

        internal static void SetAutoTypeObfuscationOptions(this PwGroup group, AutoTypeObfuscationOptions option) {
            foreach (PwEntry entry in group.GetEntries(bIncludeSubGroupEntries: true)) {
                entry.SetAutoTypeObfuscationOptions(option);
            }
        }
    }
}
