// -----------------------------------------------------------------------
// <copyright file="EndConditionsCompat.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the MIT license.
// </copyright>
// -----------------------------------------------------------------------

namespace Scp343.Compatibility
{
    using System.Reflection;
    using Exiled.API.Features;
    using Exiled.Loader;
    using Scp343.Roles;

    /// <summary>
    /// Handles integration with the EndConditions plugin.
    /// </summary>
    public class EndConditionsCompat
    {
        private readonly Scp343Role scp343Role;
        private readonly bool endConditionsInstalled;
        private readonly PropertyInfo blacklistedPlayersProperty;
        private readonly PropertyInfo modifiedRolesProperty;

        /// <summary>
        /// Initializes a new instance of the <see cref="EndConditionsCompat"/> class.
        /// </summary>
        /// <param name="scp343Role">An instance of the <see cref="Scp343Role"/> class.</param>
        public EndConditionsCompat(Scp343Role scp343Role)
        {
            this.scp343Role = scp343Role;
            foreach (Assembly pluginAssembly in Loader.Locations.Keys)
            {
                if (pluginAssembly.GetName().Name != "EndConditions")
                    continue;

                blacklistedPlayersProperty = pluginAssembly.GetType("EndConditions.API")?.GetProperty("BlacklistedPlayers", BindingFlags.Public | BindingFlags.Static);
                modifiedRolesProperty = pluginAssembly.GetType("EndConditions.API")?.GetProperty("ModifiedRoles", BindingFlags.Public | BindingFlags.Static);
                endConditionsInstalled = blacklistedPlayersProperty != null && modifiedRolesProperty != null;
                if (endConditionsInstalled)
                {
                    Log.Info("EndConditions compatibility enabled! You can declare Scp343 in your EndConditions config just like any other class.");
                    break;
                }
            }
        }

        /// <inheritdoc cref="Exiled.CustomRoles.API.Features.CustomRole.RoleAdded(Player)"/>
        public void OnRoleAdded(Player player)
        {
            if (!endConditionsInstalled)
                return;

            if (scp343Role.IsScp)
            {
                object cln = modifiedRolesProperty.GetValue(this, null);
                modifiedRolesProperty.PropertyType.GetMethod("set_Item")?.Invoke(cln, new object[] { player, "Scp343" });
            }
            else
            {
                object cln = blacklistedPlayersProperty.GetValue(this, null);
                blacklistedPlayersProperty.PropertyType.GetMethod("Add")?.Invoke(cln, new object[] { player });
            }
        }

        /// <inheritdoc cref="Exiled.CustomRoles.API.Features.CustomRole.RoleRemoved(Player)"/>
        public void OnRoleRemoved(Player player)
        {
            if (!endConditionsInstalled)
                return;

            if (scp343Role.IsScp)
            {
                object cln = modifiedRolesProperty.GetValue(this, null);
                modifiedRolesProperty.PropertyType.GetMethod("Remove")?.Invoke(cln, new object[] { player });
            }
            else
            {
                object cln = blacklistedPlayersProperty.GetValue(this, null);
                blacklistedPlayersProperty.PropertyType.GetMethod("Remove")?.Invoke(cln, new object[] { player });
            }
        }
    }
}