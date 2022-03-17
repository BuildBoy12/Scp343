// -----------------------------------------------------------------------
// <copyright file="Allegiance.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp343.Enums
{
    /// <summary>
    /// Represents Scp343's standing in a round.
    /// </summary>
    public enum Allegiance
    {
        /// <summary>
        /// Represents having no allegiance to a particular faction.
        /// </summary>
        None,

        /// <summary>
        /// Represents having allegiance to the scp faction.
        /// </summary>
        Scp,

        /// <summary>
        /// Represents having a possibility of either having no allegiance or an allegiance to the scp faction.
        /// </summary>
        Dynamic,
    }
}