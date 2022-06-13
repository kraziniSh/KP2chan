using KeePassLib;
using KeePassLib.Collections;

namespace KP2chan {
    internal static class PwGroupExtension {
        internal static void SetAutoTypeObfuscationOptions(
            this PwGroup group,
            AutoTypeObfuscationOptions option
            ) {
            foreach (PwEntry entry in group.Entries) entry.SetAutoTypeObfuscationOptions(option);
        }
    }
}
