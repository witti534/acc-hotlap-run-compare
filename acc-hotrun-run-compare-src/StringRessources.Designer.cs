﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace acc_hotlab_private_run_compare {
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
    internal class StringRessources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StringRessources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("acc_hotlab_private_run_compare.StringRessources", typeof(StringRessources).Assembly);
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
        ///   Looks up a localized string similar to Date (oldest to newest).
        /// </summary>
        internal static string orderByDateOldestFirst {
            get {
                return ResourceManager.GetString("orderByDateOldestFirst", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Date (newest to oldest).
        /// </summary>
        internal static string orderByDateOldestLast {
            get {
                return ResourceManager.GetString("orderByDateOldestLast", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Fastest lap (fastest to slowest).
        /// </summary>
        internal static string orderByFastestLapFastestFirst {
            get {
                return ResourceManager.GetString("orderByFastestLapFastestFirst", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Fastest lap (slowest to fastest).
        /// </summary>
        internal static string orderByFastestLapFastestLast {
            get {
                return ResourceManager.GetString("orderByFastestLapFastestLast", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Total time (shortest to longest).
        /// </summary>
        internal static string orderByTotalTimeShortestFirst {
            get {
                return ResourceManager.GetString("orderByTotalTimeShortestFirst", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Total time (longest to shortest).
        /// </summary>
        internal static string orderByTotalTimeShortestLast {
            get {
                return ResourceManager.GetString("orderByTotalTimeShortestLast", resourceCulture);
            }
        }
    }
}