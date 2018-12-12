﻿using Smod2;
using Smod2.API;
using Smod2.Attributes;
using System.Collections.Generic;

namespace SCP_343
{
	[PluginDetails(
	author = "Mith",
	name = "SCP-343",
	description = "SCP-343 is a passive immortal D-Class Personnel. He spawns with one Flashlight and any weapon he picks up is morphed to prevent violence. He seeks to help out who he deems worthy.",
	id = "Mith.SCP-343",
	version = "1.2.11",
	SmodMajor = 3,
	SmodMinor = 1,
	SmodRevision = 22
	)]
	class SCP343 : Plugin
	{
		public static IDictionary<string, bool> checkSteamIDIf343Dict =
			new Dictionary<string, bool>();
		public static IDictionary<string, string> checkSteamIDforBadgeName =
			new Dictionary<string, string>();
		public static IDictionary<string, string> checkSteamIDforBadgeColor =
			new Dictionary<string, string>(); // .NET 3.5 doesn't have tuples >:(
		public static IDictionary<Team, int> teamAliveCount =
			new Dictionary<Team, int>();

		public static int SCP343_HP;
		public static int SCP343_OpenDoorTime;
		public static bool SCP343_ConvertItems;
		public static bool Nuke_Interact;
		public static bool scp343_debug;
		public static int[] itemConvertList;
		public static int[] convertedItemList;
		public static int[] itemBlackList;
		public static List<string> active343List = new List<string>();
		//stores steamID of active 343s.

		public override void OnDisable()
		{
			this.Info("SCP-343 has been Disabled.");
		}
		
		public override void OnEnable()
		{
			this.Info("SCP-343 has been Enabled.");
		}

		public override void Register()
		{
			this.AddEventHandlers(new EventLogic(this));

			this.AddCommand("spawnscp343", new SpawnSCP343(this));
			this.AddCommand("scp343_version", new SCP343_Version(this));
			this.AddCommand("scp343_disable", new SCP343_Disable(this));

			this.AddConfig(new Smod2.Config.ConfigSetting("scp343_spawnchance", 10f, Smod2.Config.SettingType.FLOAT, true, "Percent chance for SPC-343 to spawn at the start of the round."));
			this.AddConfig(new Smod2.Config.ConfigSetting("scp343_itemconverttoggle", false, Smod2.Config.SettingType.BOOL, true, "Should SPC-343 convert items?"));
			this.AddConfig(new Smod2.Config.ConfigSetting("scp343_opendoortime", 300, Smod2.Config.SettingType.NUMERIC, true, "How long in seconds till SPC-343 can open any door."));
			this.AddConfig(new Smod2.Config.ConfigSetting("scp343_hp", -1, Smod2.Config.SettingType.NUMERIC, true, "How much health should SCP-343 have. Set to -1 for GodMode."));
			this.AddConfig(new Smod2.Config.ConfigSetting("scp343_nuke_interact", true, Smod2.Config.SettingType.BOOL, true, "Should SPC-343 beable to interact with the nuke."));
			this.AddConfig(new Smod2.Config.ConfigSetting("scp343_disable", false, Smod2.Config.SettingType.BOOL, true, "Should SPC-343 beable to interact with the nuke."));
			this.AddConfig(new Smod2.Config.ConfigSetting("scp343_debug", false, Smod2.Config.SettingType.BOOL, true, "Internal testing config so I stop pushing commits that are broken >:("));
			
			//https://github.com/Grover-c13/Smod2/wiki/Enum-Lists#itemtype
			this.AddConfig(new Smod2.Config.ConfigSetting("scp343_itemdroplist", new int[] {0,1,2,3,4,5,6,7,8,9,10,11,14,17,19,22,27,28,29 }, Smod2.Config.SettingType.NUMERIC_LIST, true, "What items SCP-343 drops instead of picking up."));
			this.AddConfig(new Smod2.Config.ConfigSetting("scp343_itemstoconvert", new int[]{13,16,20,21,23,24,25,26}, Smod2.Config.SettingType.NUMERIC_LIST, true, "What items SCP-343 converts."));
			this.AddConfig(new Smod2.Config.ConfigSetting("scp343_converteditems", new int[]{15}, Smod2.Config.SettingType.NUMERIC_LIST, true, "What a item should be converted to."));
		}
	}
}