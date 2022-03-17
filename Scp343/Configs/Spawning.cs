// -----------------------------------------------------------------------
// <copyright file="Spawning.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp343.Configs
{
    using System.ComponentModel;
    using UnityEngine;

    /// <summary>
    /// Handles configs related to spawning a <see cref="Roles.Scp343Role"/>.
    /// </summary>
    public class Spawning
    {
        private float spawnChance = 10f;

        /// <summary>
        /// Gets or sets the amount of <see cref="RoleType.ClassD"/> that must spawn for Scp343 to have a chance to spawn.
        /// </summary>
        [Description("The amount of ClassD that must spawn for Scp343 to have a chance to spawn.")]
        public int RequiredClassD { get; set; } = 2;

        /// <summary>
        /// Gets or sets the chance for Scp343 to spawn in a given round.
        /// </summary>
        [Description("The chance for Scp343 to spawn in a given round.")]
        public float SpawnChance
        {
            get => spawnChance;
            set => spawnChance = Mathf.Clamp(value, 0f, 100f);
        }
    }
}