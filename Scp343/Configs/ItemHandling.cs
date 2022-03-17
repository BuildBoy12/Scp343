// -----------------------------------------------------------------------
// <copyright file="ItemHandling.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp343.Configs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Exiled.API.Enums;
    using Exiled.API.Extensions;
    using Exiled.API.Features;
    using Exiled.CustomItems.API.Features;

    /// <summary>
    /// Handles configs related to handling a <see cref="Roles.Scp343Role"/>'s picked up items.
    /// </summary>
    public class ItemHandling
    {
        /// <summary>
        /// Gets or sets the types of items that Scp343 will drop when picked up.
        /// </summary>
        [Description("The types of items that Scp343 will drop when picked up. This has priority over the convert config. Accepts custom item names.")]
        public HashSet<string> ToDrop { get; set; } = new HashSet<string>
        {
            $"{ItemType.Adrenaline}",
            $"{ItemType.Coin}",
            $"{ItemType.Medkit}",
            $"{ItemType.Painkillers}",
            $"{ItemType.Radio}",
            $"{ItemType.KeycardGuard}",
            $"{ItemType.KeycardJanitor}",
            $"{ItemType.KeycardO5}",
            $"{ItemType.KeycardScientist}",
            $"{ItemType.KeycardChaosInsurgency}",
            $"{ItemType.KeycardContainmentEngineer}",
            $"{ItemType.KeycardFacilityManager}",
            $"{ItemType.KeycardResearchCoordinator}",
            $"{ItemType.KeycardZoneManager}",
            $"{ItemType.KeycardNTFCommander}",
            $"{ItemType.KeycardNTFLieutenant}",
            $"{ItemType.KeycardNTFOfficer}",
            $"{ItemType.SCP018}",
            $"{ItemType.SCP207}",
            $"{ItemType.SCP244a}",
            $"{ItemType.SCP244b}",
            $"{ItemType.SCP268}",
            $"{ItemType.SCP330}",
            $"{ItemType.SCP500}",
            $"{ItemType.SCP2176}",
        };

        /// <summary>
        /// Gets or sets the types of items that Scp343 will convert when picked up.
        /// </summary>
        [Description("The types of items that Scp343 will convert when picked up. Accepts custom item names.")]
        public HashSet<string> ToConvert { get; set; } = new HashSet<string>
        {
            $"{ItemType.MicroHID}",
            $"{ItemType.GunCrossvec}",
            $"{ItemType.GunLogicer}",
            $"{ItemType.GunRevolver}",
            $"{ItemType.GunShotgun}",
            $"{ItemType.GunAK}",
            $"{ItemType.GunCOM15}",
            $"{ItemType.GunCOM18}",
            $"{ItemType.GunE11SR}",
            $"{ItemType.GunFSP9}",
            $"{ItemType.ArmorCombat}",
            $"{ItemType.ArmorHeavy}",
            $"{ItemType.ArmorLight}",
            $"{ItemType.GrenadeFlash}",
            $"{ItemType.GrenadeHE}",
        };

        /// <summary>
        /// Gets or sets a list of the items an item in the <see cref="ToConvert"/> config can convert into.
        /// </summary>
        [Description("A list of the items an item in the ToConvert config can convert into. Accepts custom item names.")]
        public HashSet<string> ConvertedItems { get; set; } = new HashSet<string>
        {
            $"{ItemType.Flashlight}",
        };

        /// <summary>
        /// Gets or sets a collection of ammo types and the amount to add to a Scp343 if the item is converted into ammo.
        /// </summary>
        [Description("A collection of ammo types and the amount to add to a Scp343 if the item is converted into ammo.")]
        public Dictionary<AmmoType, ushort> AmountToAdd { get; set; } = new Dictionary<AmmoType, ushort>
        {
            { AmmoType.Nato9, 50 },
            { AmmoType.Nato556, 50 },
            { AmmoType.Nato762, 50 },
            { AmmoType.Ammo12Gauge, 50 },
            { AmmoType.Ammo44Cal, 50 },
        };

        /// <summary>
        /// Adds a converted item to a player's inventory.
        /// </summary>
        /// <param name="player">The player to add the converted item to.</param>
        public void Convert(Player player)
        {
            if (ConvertedItems == null || ConvertedItems.Count == 0)
                return;

            string itemName = ConvertedItems.ElementAt(Exiled.Loader.Loader.Random.Next(ConvertedItems.Count));
            if (CustomItem.TryGet(itemName, out CustomItem customItem))
            {
                customItem.Give(player);
                return;
            }

            if (Enum.TryParse(itemName, true, out ItemType result))
            {
                if (!result.IsAmmo())
                {
                    player.AddItem(result);
                    return;
                }

                player.Ammo[result] += AmountToAdd.TryGetValue(result.GetAmmoType(), out ushort amount) ? amount : (ushort)50;
            }
        }
    }
}