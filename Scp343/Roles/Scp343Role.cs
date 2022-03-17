// -----------------------------------------------------------------------
// <copyright file="Scp343Role.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp343.Roles
{
    using System;
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
        private WarheadEvents warheadEvents;

        /// <inheritdoc />
        public override uint Id { get; set; } = 343;

        /// <inheritdoc />
        public override int MaxHealth { get; set; } = 100;

        /// <inheritdoc />
        public override string Name { get; set; } = "Scp-343";

        /// <inheritdoc />
        public override List<string> Inventory { get; set; } = new List<string>
        {
            $"{ItemType.Flashlight}",
        };

        /// <inheritdoc />
        [YamlIgnore]
        public override string Description
        {
            get => RoundCondition.IsScp ? ScpDescription : NoneDescription;
            set => throw new InvalidOperationException();
        }

        /// <inheritdoc />
        [YamlIgnore]
        public override string CustomInfo
        {
            get => RoundCondition.IsScp ?
                $"<color={Misc.AllowedColors[ScpColorType]}>{Name}</color>" :
                $"<color={Misc.AllowedColors[NoneColorType]}>{Name}</color>";
            set => throw new InvalidOperationException();
        }

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
        public override bool RemovalKillsPlayer { get; set; }

        /// <summary>
        /// Gets or sets the description of Scp343 when they are considered to be an Scp.
        /// </summary>
        [Description("The description of Scp343 when they are considered to be an Scp.")]
        public string ScpDescription { get; set; } = "Scp-343 is an immortal that wonders the facility destroying weapons to aid the Scps.";

        /// <summary>
        /// Gets or sets the description of Scp343 when they are considered to have no allegiance.
        /// </summary>
        [Description("The description of Scp343 when they are considered to have no allegiance.")]
        public string NoneDescription { get; set; } = "Scp-343 is a passive immortal that wonders the facility bringing subtle anarchy.";

        /// <summary>
        /// Gets or sets the color of Scp343's custom info when they are considered to be an Scp.
        /// </summary>
        [Description("The color of Scp343's custom info when they are considered to be an Scp.")]
        public Misc.PlayerInfoColorTypes ScpColorType { get; set; } = Misc.PlayerInfoColorTypes.Crimson;

        /// <summary>
        /// Gets or sets the color of Scp343's custom info when they are considered to be on no team.
        /// </summary>
        [Description("The color of Scp343's custom info when they are considered to be on no team.")]
        public Misc.PlayerInfoColorTypes NoneColorType { get; set; } = Misc.PlayerInfoColorTypes.BlueGreen;

        /// <summary>
        /// Gets or sets a value indicating whether Scp343 should have infinite stamina.
        /// </summary>
        [Description("Whether Scp343 should have infinite stamina.")]
        public bool InfiniteStamina { get; set; } = true;

        /// <summary>
        /// Gets or sets configs related to interactions with facility objects.
        /// </summary>
        public FacilityInteractions FacilityInteractions { get; set; } = new FacilityInteractions();

        /// <summary>
        /// Gets or sets configs related to converting picked up items.
        /// </summary>
        public ItemHandling ItemHandling { get; set; } = new ItemHandling();

        /// <summary>
        /// Gets or sets configs relating to how Scp343 is considered during the round.
        /// </summary>
        public RoundCondition RoundCondition { get; set; } = new RoundCondition();

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
            warheadEvents = new WarheadEvents(this);
            warheadEvents.Subscribe();
            base.SubscribeEvents();
        }

        /// <inheritdoc />
        protected override void UnsubscribeEvents()
        {
            playerEvents.Unsubscribe();
            playerEvents = null;
            serverEvents.Unsubscribe();
            serverEvents = null;
            warheadEvents.Unsubscribe();
            warheadEvents = null;
            endConditionsCompat = null;
            base.UnsubscribeEvents();
        }

        /// <inheritdoc />
        protected override void RoleAdded(Player player)
        {
            endConditionsCompat.OnRoleAdded(player);
            if (InfiniteStamina)
                player.IsUsingStamina = false;
        }

        /// <inheritdoc />
        protected override void RoleRemoved(Player player)
        {
            endConditionsCompat.OnRoleRemoved(player);
            player.IsUsingStamina = true;
        }
    }
}