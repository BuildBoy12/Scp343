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
    using RemoteAdmin;

    /// <inheritdoc />
    public class Plugin : Plugin<Config>
    {
        /// <summary>
        /// Gets the only existing instance of the <see cref="Plugin"/> class.
        /// </summary>
        public static Plugin Instance { get; private set; }

        /// <inheritdoc/>
        public override string Author => "Build";

        /// <inheritdoc/>
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);

        /// <inheritdoc />
        public override void OnEnabled()
        {
            Instance = this;
            Config.Scp343Role.Register();
            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            Config.Scp343Role.Unregister();
            Instance = null;
            base.OnDisabled();
        }

        /// <inheritdoc />
        public override void OnRegisteringCommands()
        {
            QueryProcessor.DotCommandHandler.RegisterCommand(Config.RevertCommand);
        }

        /// <inheritdoc />
        public override void OnUnregisteringCommands()
        {
            QueryProcessor.DotCommandHandler.UnregisterCommand(Config.RevertCommand);
        }
    }
}