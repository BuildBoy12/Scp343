// -----------------------------------------------------------------------
// <copyright file="Scp343Role.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp343.Roles
{
    using Exiled.API.Features.Attributes;
    using Exiled.CustomRoles.API.Features;
    using Scp343.Configs;
    using Scp343.EventHandlers;

    /// <inheritdoc />
    [CustomRole(RoleType.ClassD)]
    public class Scp343Role : CustomRole
    {
        private PlayerEvents playerEvents;
        private ServerEvents serverEvents;

        /// <inheritdoc />
        public override uint Id { get; set; } = 343;

        /// <inheritdoc />
        public override RoleType Role { get; set; } = RoleType.ClassD;

        /// <inheritdoc />
        public override int MaxHealth { get; set; } = 100;

        /// <inheritdoc />
        public override string Name { get; set; } = "Scp-343";

        /// <inheritdoc/>
        public override string Description { get; set; } = "SCP-343 is a passive immortal that wonders the facility bringing subtle anarchy to the table.";

        /// <inheritdoc />
        public override string CustomInfo { get; set; } = "Scp-343";

        /// <summary>
        /// Gets or sets configs related to converting picked up items.
        /// </summary>
        public ItemConverting ItemConverting { get; set; } = new ItemConverting();

        /// <summary>
        /// Gets or sets configs related to spawning.
        /// </summary>
        public Spawning Spawning { get; set; } = new Spawning();

        /// <inheritdoc />
        protected override void SubscribeEvents()
        {
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
            base.UnsubscribeEvents();
        }
    }
}