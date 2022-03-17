# This plugin is archived meaning it will ***NOT*** be updated.


# [SCP-343](http://www.scp-wiki.net/scp-343)
This is a server plugin for [SCP:SL](https://scpslgame.com/).
## Install Instructions.
Put the Scp343.dll under the release tab into the Plugins folder.


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
| description | String | SCP-343 is a passive immortal that wonders the facility bringing a subtle anarchy. | The description of the command. |
| time | Integer | 30 | The amount of elapsed seconds in a round before the command cannot be used. |
| disabled_response | String | This command is disabled. | The response to send to a player when the command was disabled. |
| not343_response | String | This command may only be executed by Scp343. | The response to send to a player when they are not Scp343. |
| exceeded_revert_time_response | String | This command may only be used in the first $seconds seconds of the game. | The response to send a player when the elapsed time exceeds the time config.. |
| successful_response | String | You are no longer Scp343 and can continue as a normal ClassD. | The response to send a player that has been removed from the Scp343 role. |

## Lore Friendly Description 
SCP-343 is a passive immortal D-Class Personnel. He spawns with one Flashlight and any weapon he picks up is morphed to prevent violence. He seeks to help out who he deems worthy.

## Technical Description  
To be clear, this isn't the correct wiki version SCP-343. It's just a passive SCP inspired by my experiences of people being Tutorial running around messing with people.

Technically speaking, he's a D-Class with godmode enabled or HP with the config option and spawns with the D-Class. After a X minute period set by the server, he can open every door in the game. Also, to make sure he is passive, every weapon he picks up or spawns with is converted to a flashlight or something the server config can change.
