﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KP2chan.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class KP2chan {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal KP2chan() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("KP2chan.Resources.KP2chan", typeof(KP2chan).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Disable 2CATO everywhere.
        /// </summary>
        internal static string mainDisableAllButton {
            get {
                return ResourceManager.GetString("mainDisableAllButton", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enable 2CATO everywhere.
        /// </summary>
        internal static string mainEnableAllButton {
            get {
                return ResourceManager.GetString("mainEnableAllButton", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [KP2chan] Please open a database first!.
        /// </summary>
        internal static string noDatabaseOpened {
            get {
                return ResourceManager.GetString("noDatabaseOpened", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to kp2chan.
        /// </summary>
        internal static string pluginName {
            get {
                return ResourceManager.GetString("pluginName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [KP2chan] 2CATO disabled for all entries..
        /// </summary>
        internal static string tcatoDisabledAll {
            get {
                return ResourceManager.GetString("tcatoDisabledAll", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [KP2chan] 2CATO enabled for all entries..
        /// </summary>
        internal static string tcatoEnabledAll {
            get {
                return ResourceManager.GetString("tcatoEnabledAll", resourceCulture);
            }
        }
    }
}