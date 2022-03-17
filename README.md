# [SCP-343](http://www.scp-wiki.net/scp-343)
This is a server plugin for [SCP:SL](https://scpslgame.com/).

## Install Instructions.
Put the Scp343.dll under the release tab into the Plugins folder.

## Lore Friendly Description 
SCP-343 is a passive immortal D-Class Personnel. He spawns with one Flashlight and any weapon he picks up is morphed to prevent violence. He seeks to help out who he deems worthy.

## Technical Description  
To be clear, this isn't the correct wiki version SCP-343. It's just a passive SCP inspired by my experiences of people being Tutorial running around messing with people.

Technically speaking, he's a D-Class with godmode enabled or HP with the config option and spawns with the D-Class. After a X minute period set by the server, he can open every door in the game. Also, to make sure he is passive, every weapon he picks up or spawns with is converted to a flashlight or something the server config can change.

# Configs

## Main
| Config        | Type | Default | Description |
| :-------------: | :---------: | :---------: | :------: |
| is_enabled | Boolean | True | Whether the plugin should load. |

## Revert Command
| Config        | Type | Default | Description |
| :-------------: | :---------: | :---------: | :------: |
| is_enabled | Boolean | True | Whether the command is enabled. |
| command | String | revert | The name of the command. |
| aliases | String Array | null | The aliases of the command. |
| description | String | Allows a class-d to throw away the 343 role. | The description of the command. |
| time | Integer | 30 | The amount of elapsed seconds in a round before the command cannot be used. |
| disabled_response | String | This command is disabled. | The response to send to a player when the command was disabled. |
| not343_response | String | This command may only be executed by Scp343. | The response to send to a player when they are not Scp343. |
| exceeded_revert_time_response | String | This command may only be used in the first $seconds seconds of the game. | The response to send a player when the elapsed time exceeds the time config.. |
| successful_response | String | You are no longer Scp343 and can continue as a normal ClassD. | The response to send a player that has been removed from the Scp343 role. |

## Scp343 Role
| Config        | Type | Default | Description |
| :-------------: | :---------: | :---------: | :------: |
| id | Integer | 343 | The ID of the custom role. |
| max_health | Integer | 100 | The maximum health of Scp343. |
| name | String | Scp-343 | The name of the custom role. |
| inventory | String List | Flashlight | The items Scp343 will spawn with. Accepts custom items. |
| scp_description | String | Scp-343 is an immortal that wonders the facility destroying weapons to aid the Scps. | The description of Scp343 when they are considered to be an Scp. |
| none_description | String | Scp-343 is a passive immortal that wonders the facility bringing a subtle anarchy. | The description of Scp343 when they are considered to have no allegiance. |
| scp_color_type | PlayerInfoColorTypes | Crimson | The color of Scp343's custom info when they are considered to be an Scp. |
| none_color_type | PlayerInfoColorTypes | BlueGreen | The color of Scp343's custom info when they are considered to be on no team. |
| infinite_stamina | Boolean | True | Whether Scp343 should have infinite stamina. |

### Facility Interactions
| Config        | Type | Default | Description |
| :-------------: | :---------: | :---------: | :------: |
| open_door_time | Integer | 300 | The amount of time, in seconds, before Scp343 can open any door regardless of permissions. Set to -1 to disable. |
| nuke_interact | Boolean | False | Whether Scp343 can interact with the alpha warhead. |
| trigger_teslas | Boolean | False | Whether Scp343 will trigger tesla gates. |

### Item Handling
| Config        | Type | Default | Description |
| :-------------: | :---------: | :---------: | :------: |
| to_drop | String HashSet | Adrenaline, Coin, Medkit, Painkillers, Radio, KeycardGuard, KeycardJanitor, KeycardO5, KeycardScientist, KeycardChaosInsurgency, KeycardContainmentEngineer, KeycardFacilityManager, KeycardResearchCoordinator, KeycardZoneManager, KeycardNTFCommander, KeycardNTFLieutenant, KeycardNTFOfficer, SCP018, SCP207, SCP244a, SCP244b, SCP268, SCP330, SCP500, SCP2176 | The types of items that Scp343 will drop when picked up. This has priority over the convert config. Accepts custom item names. |
| to_convert | String Hashset | MicroHID, GunCrossvec, GunLogicer, GunRevolver, GunShotgun, GunAK, GunCOM15, GunCOM18, GunE11SR, GunFSP9, ArmorCombat, ArmorHeavy, ArmorLight, GrenadeFlash, GrenadeHE | The types of items that Scp343 will convert when picked up. Accepts custom item names. |
| converted_items | String Hashset | Flashlight | A list of the items an item in the ToConvert config can convert into. Accepts custom item names. |
| amount_to_add | AmmoType-UShort Dictionary | Nato9: 50, Nato556: 50, Nato762: 50, Ammo12Gauge: 50, Ammo44Cal: 50 | A collection of ammo types and the amount to add to a Scp343 if the item is converted into ammo. |

### Round Condition

Scp343's allegiance determines when the round ends. If set to None, it has no impact on the round and will have invincibility. If set to Scp, it will lose its invincibility and will count towards and win with the Scp team. If set to Dynamic, it has a 50/50 chance of being either with the None team or Scp team each round.
| Config        | Type | Default | Description |
| :-------------: | :---------: | :---------: | :------: |
| allegiance | Allegiance | None | Scp343's team allegiance. Available: None, Scp, Dynamic |

### Spawning
| Config        | Type | Default | Description |
| :-------------: | :---------: | :---------: | :------: |
| required_class_d | Integer | 2 | The amount of ClassD that must spawn for Scp343 to have a chance to spawn. |
| spawn_chance | Float | 10 | The chance for Scp343 to spawn in a given round. |
