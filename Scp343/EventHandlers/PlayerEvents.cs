// -----------------------------------------------------------------------
// <copyright file="PlayerEvents.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp343.EventHandlers
{
    using Exiled.API.Features;
    using Exiled.CustomItems.API.Features;
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
            PlayerHandlers.EnteringPocketDimension += OnEnteringPocketDimension;
            PlayerHandlers.Hurting += OnHurting;
            PlayerHandlers.InteractingDoor += OnInteractingDoor;
            PlayerHandlers.PickingUpItem += OnPickingUpItem;
            PlayerHandlers.TriggeringTesla += OnTriggeringTesla;
        }

        /// <summary>
        /// Unsubscribes from all required events.
        /// </summary>
        public void Unsubscribe()
        {
            PlayerHandlers.EnteringPocketDimension -= OnEnteringPocketDimension;
            PlayerHandlers.Hurting -= OnHurting;
            PlayerHandlers.InteractingDoor -= OnInteractingDoor;
            PlayerHandlers.PickingUpItem -= OnPickingUpItem;
            PlayerHandlers.TriggeringTesla -= OnTriggeringTesla;
        }

        private void OnEnteringPocketDimension(EnteringPocketDimensionEventArgs ev)
        {
            if (scp343Role.Check(ev.Player))
                ev.IsAllowed = false;
        }

        private void OnHurting(HurtingEventArgs ev)
        {
            if (scp343Role.Check(ev.Target) && !scp343Role.RoundCondition.IsScp)
                ev.IsAllowed = false;
        }

        private void OnInteractingDoor(InteractingDoorEventArgs ev)
        {
            if (scp343Role.FacilityInteractions.OpenDoorTime > -1 &&
                scp343Role.Check(ev.Player) &&
                Round.ElapsedTime.TotalSeconds >= scp343Role.FacilityInteractions.OpenDoorTime)
                ev.IsAllowed = true;
        }

        private void OnPickingUpItem(PickingUpItemEventArgs ev)
        {
            if (!scp343Role.Check(ev.Player))
                return;

            string name = CustomItem.TryGet(ev.Pickup, out CustomItem customItem) ? customItem.Name : ev.Pickup.Type.ToString();
            if (scp343Role.ItemHandling.ToDrop.Contains(name))
            {
                ev.IsAllowed = false;
                ev.Pickup.Position = ev.Player.Position;
                return;
            }

            if (scp343Role.ItemHandling.ToConvert.Contains(name))
            {
                ev.IsAllowed = false;
                ev.Pickup.Destroy();
                scp343Role.ItemHandling.Convert(ev.Player);
            }
        }

        private void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            if (scp343Role.Check(ev.Player) && !scp343Role.FacilityInteractions.TriggerTeslas)
            {
                ev.IsInIdleRange = false;
                ev.IsTriggerable = false;
            }
        }
    }
}