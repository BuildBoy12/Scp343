// -----------------------------------------------------------------------
// <copyright file="Spawning.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp343.Configs
{
    using UnityEngine;

    /// <summary>
    /// Handles configs related to spawning a <see cref="Roles.Scp343Role"/>.
    /// </summary>
    public class Spawning
    {
        private float spawnChance = 10f;

        /// <summary>
        /// Gets or sets the amount of <see cref="RoleType.ClassD"/> must spawn for Scp343 to have a chance to spawn.
        /// </summary>
        public int RequiredClassD { get; set; } = 1;

        /// <summary>
        /// Gets or sets the chance for Scp343 to spawn in a given round.
        /// </summary>
        public float SpawnChance
        {
            get => spawnChance;
            set => spawnChance = Mathf.Clamp(value, 0f, 100f);
        }
    }
}