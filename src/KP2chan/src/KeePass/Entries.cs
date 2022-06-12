using KeePassLib;
using KeePassLib.Collections;

namespace KP2chan {
    internal static class Entries {
        internal static void SetAutoTypeObfuscationOption(
            this PwObjectList<PwEntry> entries,
            AutoTypeObfuscationOptions option
            ) {
            foreach (PwEntry entry in entries) {
                entry.AutoType.ObfuscationOptions = option;
            }
        }
    }
}
