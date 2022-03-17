// -----------------------------------------------------------------------
// <copyright file="RevertCommand.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp343.Commands
{
    using System;
    using System.ComponentModel;
    using CommandSystem;
    using Exiled.API.Features;

    /// <inheritdoc />
    public class RevertCommand : ICommand
    {
        /// <summary>
        /// Gets or sets a value indicating whether the command is enabled.
        /// </summary>
        [Description("Whether the command is enabled.")]
        public bool IsEnabled { get; set; } = true;

        /// <inheritdoc />
        public string Command { get; set; } = "revert";

        /// <inheritdoc />
        public string[] Aliases { get; set; } = null;

        /// <inheritdoc />
        public string Description { get; set; } = "Allows a class-d to throw away the 343 role.";

        /// <summary>
        /// Gets or sets the amount of elapsed seconds in a round before the command cannot be used.
        /// </summary>
        [Description("The amount of elapsed seconds in a round before the command cannot be used.")]
        public int Time { get; set; } = 30;

        /// <summary>
        /// Gets or sets the response to send to a player when the command was disabled.
        /// </summary>
        [Description("The response to send to a player when the command was disabled.")]
        public string DisabledResponse { get; set; } = "This command is disabled.";

        /// <summary>
        /// Gets or sets the response to send to a player when they are not Scp343.
        /// </summary>
        [Description("The response to send to a player when they are not Scp343.")]
        public string Not343Response { get; set; } = "This command may only be executed by Scp343.";

        /// <summary>
        /// Gets or sets the response to send a player when the <see cref="Exiled.API.Features.Round.ElapsedTime"/> exceeds the <see cref="Time"/> config.
        /// </summary>
        [Description("The response to send a player when the elapsed time exceeds the time config.")]
        public string ExceededRevertTimeResponse { get; set; } = "This command may only be used in the first $seconds seconds of the game.";

        /// <summary>
        /// Gets or sets the response to send a player that has been removed from the Scp343 role.
        /// </summary>
        [Description("The response to send a player that has been removed from the Scp343 role.")]
        public string SuccessfulResponse { get; set; } = "You are no longer Scp343 and can continue as a normal ClassD.";

        /// <inheritdoc />
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!IsEnabled)
            {
                response = DisabledResponse;
                return false;
            }

            Player playerSender = Player.Get(sender);
            if (playerSender == null)
            {
                response = "This command must be executed from the game level.";
                return false;
            }

            if (!Plugin.Instance.Config.Scp343Role.Check(playerSender))
            {
                response = Not343Response;
                return false;
            }

            if (Round.ElapsedTime.TotalSeconds > Time)
            {
                response = ExceededRevertTimeResponse.Replace("$seconds", Time.ToString());
                return false;
            }

            Plugin.Instance.Config.Scp343Role.RemoveRole(playerSender);
            playerSender.ClearInventory();
            playerSender.Health = playerSender.MaxHealth;

            response = SuccessfulResponse;
            return true;
        }
    }
}