// -----------------------------------------------------------------------
// <copyright file="ItemHandling.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp343.Configs
{
    using System.Collections.Generic;

    /// <summary>
    /// Handles configs related to handling a <see cref="Roles.Scp343Role"/>'s picked up items.
    /// </summary>
    public class ItemHandling
    {
        /// <summary>
        /// Gets or sets the types of items that Scp343 will drop when picked up.
        /// </summary>
        public List<ItemType> Drop { get; set; } = new List<ItemType>();

        /// <summary>
        /// Gets or sets the types of items that Scp343 will convert when picked up.
        /// </summary>
        public List<ItemType> Convert { get; set; } = new List<ItemType>
        {
            ItemType.MicroHID,
        };
    }
}