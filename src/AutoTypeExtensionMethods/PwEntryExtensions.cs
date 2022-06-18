using KeePassLib;
using KeePassLib.Collections;

namespace KP2chan {
    internal static class PwEntryExtensions {
        internal static void SetAutoType(this PwEntry entry, bool enabled) {
            entry.AutoType.Enabled = enabled;
        }

        internal static void SetAutoTypeObfuscationOptions(this PwEntry entry, AutoTypeObfuscationOptions option) {
            if (option == AutoTypeObfuscationOptions.UseClipboard) entry.SetAutoType(true);
            entry.AutoType.ObfuscationOptions = option;
        }
    }
}
