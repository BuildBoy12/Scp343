// -----------------------------------------------------------------------
// <copyright file="WarheadEvents.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp343.EventHandlers
{
    using Exiled.Events.EventArgs;
    using Scp343.Roles;
    using WarheadHandlers = Exiled.Events.Handlers.Warhead;

    /// <summary>
    /// Handles events derived from <see cref="Exiled.Events.Handlers.Warhead"/>.
    /// </summary>
    public class WarheadEvents
    {
        private readonly Scp343Role scp343Role;

        /// <summary>
        /// Initializes a new instance of the <see cref="WarheadEvents"/> class.
        /// </summary>
        /// <param name="scp343Role">An instance of the <see cref="Scp343Role"/> class.</param>
        public WarheadEvents(Scp343Role scp343Role) => this.scp343Role = scp343Role;

        /// <summary>
        /// Subscribes to all required events.
        /// </summary>
        public void Subscribe()
        {
            WarheadHandlers.ChangingLeverStatus += OnChangingLeverStatus;
            WarheadHandlers.Starting += OnStarting;
            WarheadHandlers.Stopping += OnStopping;
        }

        /// <summary>
        /// Unsubscribes from all required events.
        /// </summary>
        public void Unsubscribe()
        {
            WarheadHandlers.ChangingLeverStatus -= OnChangingLeverStatus;
            WarheadHandlers.Starting -= OnStarting;
            WarheadHandlers.Stopping -= OnStopping;
        }

        private void OnChangingLeverStatus(ChangingLeverStatusEventArgs ev)
        {
            if (scp343Role.Check(ev.Player) && !scp343Role.FacilityInteractions.NukeInteract)
                ev.IsAllowed = false;
        }

        private void OnStarting(StartingEventArgs ev)
        {
            if (ev.Player != null && scp343Role.Check(ev.Player) && !scp343Role.FacilityInteractions.NukeInteract)
                ev.IsAllowed = false;
        }

        private void OnStopping(StoppingEventArgs ev)
        {
            if (ev.Player != null && scp343Role.Check(ev.Player) && !scp343Role.FacilityInteractions.NukeInteract)
                ev.IsAllowed = false;
        }
    }
}