// -----------------------------------------------------------------------
// <copyright file="RoundCondition.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp343.Configs
{
    using System.ComponentModel;
    using Scp343.Enums;
    using YamlDotNet.Serialization;

    /// <summary>
    /// Handles configs related to how Scp343 is perceived in a round.
    /// </summary>
    public class RoundCondition
    {
        private bool isScp;

        /// <summary>
        /// Gets a value indicating whether Scp343 should be considered as an Scp.
        /// </summary>
        [YamlIgnore]
        public bool IsScp => Allegiance == Allegiance.Scp ||
                             (Allegiance == Allegiance.Dynamic && isScp);

        /// <summary>
        /// Gets or sets Scp343's team allegiance.
        /// </summary>
        [Description("Scp343's team allegiance. Available: None, Scp, Dynamic")]
        public Allegiance Allegiance { get; set; } = Allegiance.None;

        /// <summary>
        /// Updates the allegiance that the dynamic setting should inherit.
        /// </summary>
        public void UpdateDynamicAllegiance() => isScp = Exiled.Loader.Loader.Random.Next(1) == 0;
    }
}