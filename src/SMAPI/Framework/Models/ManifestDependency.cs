namespace StardewModdingAPI.Framework.Models
{
    /// <summary>A mod dependency listed in a mod manifest.</summary>
    internal class ManifestDependency : IManifestDependency
    {
        /*********
        ** Accessors
        *********/
        /// <summary>The unique mod ID to require.</summary>
        public string UniqueID { get; }

        /// <summary>The minimum required version (if any).</summary>
        public ISemanticVersion MinimumVersion { get; }

        /// <summary>Whether the dependency must be installed to use the mod.</summary>
        public bool IsRequired { get; }


        /*********
        ** Public methods
        *********/
        /// <summary>Construct an instance.</summary>
        /// <param name="dependency">The toolkit instance.</param>
        public ManifestDependency(Toolkit.Serialisation.Models.ManifestDependency dependency)
            : this(dependency.UniqueID, dependency.MinimumVersion?.ToString(), dependency.IsRequired) { }

        /// <summary>Construct an instance.</summary>
        /// <param name="uniqueID">The unique mod ID to require.</param>
        /// <param name="minimumVersion">The minimum required version (if any).</param>
        /// <param name="required">Whether the dependency must be installed to use the mod.</param>
        public ManifestDependency(string uniqueID, string minimumVersion, bool required = true)
        {
            this.UniqueID = uniqueID;
            this.MinimumVersion = !string.IsNullOrWhiteSpace(minimumVersion)
                ? new SemanticVersion(minimumVersion)
                : null;
            this.IsRequired = required;
        }
    }
}
