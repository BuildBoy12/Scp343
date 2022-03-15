// -----------------------------------------------------------------------
// <copyright file="ServerEvents.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp343.EventHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using MEC;
    using Scp343.Roles;
    using ServerHandlers = Exiled.Events.Handlers.Server;

    /// <summary>
    /// Handles events derived from <see cref="Exiled.Events.Handlers.Server"/>.
    /// </summary>
    public class ServerEvents
    {
        private readonly Scp343Role scp343Role;
        private readonly Random random;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerEvents"/> class.
        /// </summary>
        /// <param name="scp343Role">An instance of the <see cref="Scp343Role"/> class.</param>
        public ServerEvents(Scp343Role scp343Role)
        {
            this.scp343Role = scp343Role;
            random = Exiled.Loader.Loader.Random;
        }

        /// <summary>
        /// Subscribes to all required events.
        /// </summary>
        public void Subscribe()
        {
            ServerHandlers.EndingRound += OnEndingRound;
            ServerHandlers.RoundStarted += OnRoundStarted;
        }

        /// <summary>
        /// Unsubscribes from all required events.
        /// </summary>
        public void Unsubscribe()
        {
            ServerHandlers.EndingRound -= OnEndingRound;
            ServerHandlers.RoundStarted -= OnRoundStarted;
        }

        private void OnEndingRound(EndingRoundEventArgs ev)
        {
            RoundSummary.SumInfo_ClassList classList = new RoundSummary.SumInfo_ClassList
            {
                chaos_insurgents = ev.ClassList.chaos_insurgents,
                class_ds = ev.ClassList.class_ds - scp343Role.TrackedPlayers.Count,
                mtf_and_guards = ev.ClassList.mtf_and_guards,
                scientists = ev.ClassList.scientists,
                scps_except_zombies = ev.ClassList.scps_except_zombies,
                time = ev.ClassList.time,
                warhead_kills = ev.ClassList.warhead_kills,
                zombies = ev.ClassList.zombies,
            };

            ev.ClassList = classList;
        }

        private void OnRoundStarted()
        {
            Timing.CallDelayed(1f, () =>
            {
                List<Player> classD = Player.Get(RoleType.ClassD).ToList();
                if (classD.Count < scp343Role.Spawning.RequiredClassD || random.Next(100) > scp343Role.Spawning.SpawnChance)
                    return;

                Player selectedPlayer = classD[random.Next(classD.Count)];
                scp343Role.AddRole(selectedPlayer);
            });
        }
    }
}