using KeePassLib;
using KeePassLib.Collections;

namespace KP2chan {
    internal static class PwEntryArrayExtension {
        internal static void SetAutoTypeObfuscationOptions(
            this PwEntry[] entries,
            AutoTypeObfuscationOptions option
            ) {
            foreach (PwEntry entry in entries) entry.SetAutoTypeObfuscationOptions(option);
        }
    }
}
