using KeePassLib;
using KeePassLib.Collections;

namespace KP2chan {
    internal static class PwEntryExtension {
        internal static void SetAutoTypeObfuscationOptions(
            this PwEntry entry,
            AutoTypeObfuscationOptions option
            ) {
            if (option == AutoTypeObfuscationOptions.UseClipboard) entry.AutoType.Enabled = true;
            entry.AutoType.ObfuscationOptions = option;
        }
    }
}
