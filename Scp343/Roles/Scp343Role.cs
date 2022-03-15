// -----------------------------------------------------------------------
// <copyright file="Scp343Role.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp343.Roles
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Exiled.API.Features;
    using Exiled.API.Features.Attributes;
    using Exiled.API.Features.Spawn;
    using Exiled.CustomRoles.API.Features;
    using Scp343.Compatibility;
    using Scp343.Configs;
    using Scp343.EventHandlers;
    using YamlDotNet.Serialization;

    /// <inheritdoc />
    [CustomRole(RoleType.ClassD)]
    public class Scp343Role : CustomRole
    {
        private EndConditionsCompat endConditionsCompat;

        private PlayerEvents playerEvents;
        private ServerEvents serverEvents;

        /// <inheritdoc />
        public override uint Id { get; set; } = 343;

        /// <inheritdoc />
        public override int MaxHealth { get; set; } = 100;

        /// <inheritdoc />
        public override string Name { get; set; } = "Scp-343";

        /// <inheritdoc/>
        public override string Description { get; set; } = "SCP-343 is a passive immortal that wonders the facility bringing subtle anarchy to the facility.";

        /// <inheritdoc />
        public override string CustomInfo { get; set; } = "Scp-343";

        /// <inheritdoc />
        public override List<string> Inventory { get; set; } = new List<string>
        {
            $"{ItemType.Flashlight}",
        };

        /// <inheritdoc />
        [YamlIgnore]
        public override RoleType Role { get; set; } = RoleType.ClassD;

        /// <inheritdoc />
        [YamlIgnore]
        public override List<CustomAbility> CustomAbilities { get; set; } = new List<CustomAbility>();

        /// <inheritdoc />
        [YamlIgnore]
        public override SpawnProperties SpawnProperties { get; set; }

        /// <inheritdoc />
        [YamlIgnore]
        public override bool KeepInventoryOnSpawn { get; set; }

        /// <inheritdoc />
        [YamlIgnore]
        public override bool KeepRoleOnDeath { get; set; }

        /// <inheritdoc />
        [YamlIgnore]
        public override bool RemovalKillsPlayer { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether Scp343 should count towards the Scp team.
        /// </summary>
        [Description("Whether Scp343 should count towards the scp team.")]
        public bool IsScp { get; set; } = false;

        /// <summary>
        /// Gets or sets configs related to converting picked up items.
        /// </summary>
        public ItemHandling ItemHandling { get; set; } = new ItemHandling();

        /// <summary>
        /// Gets or sets configs related to spawning.
        /// </summary>
        public Spawning Spawning { get; set; } = new Spawning();

        /// <inheritdoc />
        protected override void SubscribeEvents()
        {
            endConditionsCompat = new EndConditionsCompat(this);
            playerEvents = new PlayerEvents(this);
            playerEvents.Subscribe();
            serverEvents = new ServerEvents(this);
            serverEvents.Subscribe();
            base.SubscribeEvents();
        }

        /// <inheritdoc />
        protected override void UnsubscribeEvents()
        {
            playerEvents.Unsubscribe();
            playerEvents = null;
            serverEvents.Unsubscribe();
            serverEvents = null;
            endConditionsCompat = null;
            base.UnsubscribeEvents();
        }

        /// <inheritdoc />
        protected override void RoleAdded(Player player)
        {
            endConditionsCompat.OnRoleAdded(player);
        }

        /// <inheritdoc />
        protected override void RoleRemoved(Player player)
        {
            endConditionsCompat.OnRoleRemoved(player);
        }
    }
}