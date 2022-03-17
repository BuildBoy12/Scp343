﻿// -----------------------------------------------------------------------
// <copyright file="FacilityInteractions.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp343.Configs
{
    using System.ComponentModel;

    /// <summary>
    /// Handles configs related to interactions with facility objects.
    /// </summary>
    public class FacilityInteractions
    {
        /// <summary>
        /// Gets or sets a value indicating whether Scp343 can interact with the alpha warhead.
        /// </summary>
        [Description("Whether Scp343 can interact with the alpha warhead.")]
        public bool NukeInteract { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether Scp343 will trigger tesla gates.
        /// </summary>
        [Description("Whether Scp343 will trigger tesla gates.")]
        public bool TriggerTeslas { get; set; } = false;
    }
}