// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp343
{
    using Exiled.API.Interfaces;
    using Scp343.Commands;
    using Scp343.Roles;

    /// <inheritdoc />
    public class Config : IConfig
    {
        /// <inheritdoc/>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets a configurable instance of the <see cref="Commands.RevertCommand"/> class.
        /// </summary>
        public RevertCommand RevertCommand { get; set; } = new RevertCommand();

        /// <summary>
        /// Gets or sets a configurable instance of the <see cref="Roles.Scp343Role"/> class.
        /// </summary>
        public Scp343Role Scp343Role { get; set; } = new Scp343Role();
    }
}