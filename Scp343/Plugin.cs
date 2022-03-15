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
    using Exiled.CustomRoles.API;

    /// <inheritdoc />
    public class Plugin : Plugin<Config>
    {
        /// <inheritdoc/>
        public override string Author => "Build";

        /// <inheritdoc/>
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);

        /// <inheritdoc />
        public override void OnEnabled()
        {
            Config.Scp343Role.Register();
            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            Config.Scp343Role.Unregister();
            base.OnDisabled();
        }
    }
}