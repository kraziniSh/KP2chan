using KeePassLib;
using KeePassLib.Collections;

namespace KP2chan {
    internal static class PwEntryArrayExtensions {
        internal static void SetAutoType(this PwEntry[] entries, bool enabled) {
            foreach (PwEntry entry in entries) entry.SetAutoType(enabled);
        }

        internal static void SetAutoTypeObfuscationOptions(this PwEntry[] entries, AutoTypeObfuscationOptions option) {
            foreach (PwEntry entry in entries) entry.SetAutoTypeObfuscationOptions(option);
        }
    }
}
