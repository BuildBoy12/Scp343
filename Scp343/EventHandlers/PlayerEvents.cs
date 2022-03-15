// -----------------------------------------------------------------------
// <copyright file="PlayerEvents.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp343.EventHandlers
{
    using Exiled.Events.EventArgs;
    using Scp343.Roles;
    using PlayerHandlers = Exiled.Events.Handlers.Player;

    /// <summary>
    /// Handles events derived from <see cref="Exiled.Events.Handlers.Player"/>.
    /// </summary>
    public class PlayerEvents
    {
        private readonly Scp343Role scp343Role;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerEvents"/> class.
        /// </summary>
        /// <param name="scp343Role">An instance of the <see cref="Scp343Role"/> class.</param>
        public PlayerEvents(Scp343Role scp343Role) => this.scp343Role = scp343Role;

        /// <summary>
        /// Subscribes to all required events.
        /// </summary>
        public void Subscribe()
        {
            PlayerHandlers.PickingUpItem += OnPickingUpItem;
        }

        /// <summary>
        /// Unsubscribes from all required events.
        /// </summary>
        public void Unsubscribe()
        {
            PlayerHandlers.PickingUpItem += OnPickingUpItem;
        }

        private void OnPickingUpItem(PickingUpItemEventArgs ev)
        {
            if (!scp343Role.Check(ev.Player))
                return;
        }
    }
}