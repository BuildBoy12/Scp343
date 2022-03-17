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
    using Exiled.API.Enums;
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
            ServerHandlers.WaitingForPlayers += OnWaitingForPlayers;
        }

        /// <summary>
        /// Unsubscribes from all required events.
        /// </summary>
        public void Unsubscribe()
        {
            ServerHandlers.EndingRound -= OnEndingRound;
            ServerHandlers.RoundStarted -= OnRoundStarted;
            ServerHandlers.WaitingForPlayers -= OnWaitingForPlayers;
        }

        private void OnEndingRound(EndingRoundEventArgs ev)
        {
            // https://github.com/Exiled-Team/EXILED/blob/dev/Exiled.Events/Patches/Events/Server/RoundEnd.cs#L90-L129
            RoundSummary.SumInfo_ClassList classList = new RoundSummary.SumInfo_ClassList
            {
                chaos_insurgents = ev.ClassList.chaos_insurgents,
                class_ds = ev.ClassList.class_ds - scp343Role.TrackedPlayers.Count,
                mtf_and_guards = ev.ClassList.mtf_and_guards,
                scientists = ev.ClassList.scientists,
                scps_except_zombies = ev.ClassList.scps_except_zombies + (scp343Role.RoundCondition.IsScp ? scp343Role.TrackedPlayers.Count : 0),
                time = ev.ClassList.time,
                warhead_kills = ev.ClassList.warhead_kills,
                zombies = ev.ClassList.zombies,
            };

            int num1 = classList.mtf_and_guards + classList.scientists;
            int num2 = classList.chaos_insurgents + classList.class_ds;
            int num3 = classList.scps_except_zombies + classList.zombies;
            int num4 = classList.class_ds + RoundSummary.EscapedClassD;
            int num5 = classList.scientists + RoundSummary.EscapedScientists;

            if (ev.ClassList.class_ds == 0 && num1 == 0)
            {
                ev.IsRoundEnded = true;
            }
            else
            {
                int num8 = 0;
                if (num1 > 0)
                    num8++;
                if (num2 > 0)
                    num8++;
                if (num3 > 0)
                    num8++;
                if (num8 <= 1)
                    ev.IsRoundEnded = true;
            }

            if (num1 > 0 && num5 > 0)
            {
                ev.LeadingTeam = LeadingTeam.FacilityForces;
            }
            else if (num4 > 0)
            {
                ev.LeadingTeam = LeadingTeam.ChaosInsurgency;
            }
            else if (num3 > 0)
            {
                ev.LeadingTeam = LeadingTeam.Anomalies;
            }
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

        private void OnWaitingForPlayers() => scp343Role.RoundCondition.UpdateDynamicAllegiance();
    }
}