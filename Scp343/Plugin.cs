// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp343
{
    using System;
    using Exiled.API.Features;

    /// <inheritdoc />
    public class Plugin : Plugin<Config>
    {
        /// <inheritdoc/>
        public override string Author => "Build";

        /// <inheritdoc/>
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);
    }
}