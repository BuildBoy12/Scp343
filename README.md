# [SCP-343](http://www.scp-wiki.net/scp-343)

| Config Option              | Value Type      | Default Value | Description |
|   :---:                    |     :---:       |    :---:      |    :---:    |
| scp343_spawnchance         | Float           | 10            | Percent chance for SPC-343 to spawn at the start of the round. |
| scp343_opendoortime        | Integer         | 300           | How many seconds till SCP-343 can open any door.               |
| scp343_hp                  | Integer         | -1            | How much health should SCP-343 have, set to -1 for GodMode.    | 
| scp343_nuke_interact       | Boolean         | true          | Should SCP-343 beable to interact with the nuke?               |
| scp343_itemconverttoggle   | Boolean         | false         | Should SPC-343 convert items?                                  |
| scp343_itemdroplist        | Integer List    | 0,1,2,3,4,5,6,7,8,9,10,11,14,17,19,22,27,28,29 | What items SCP-343 drops instead of picking up.|
| scp343_itemconversionlist  | Integer List    | 13,16,20,21,23,24,25,26 | What items SCP-343 converts. |
| scp343_itemconvertedlist   | Integer List    | 15         | What a item should be converted to.       |

| Command(s)                 | Value Type      | Description                              |
|   :---:                    |     :---:       |    :---:                                 |
| spawnscp343                | PlayerID        | Spawn SCP-343. Example = "spawnscp343 2" |
| scp343_version             | N/A             | Get the version of this plugin           |

SCP-343 is a passive immortal D-Class Personnel. He spawns with one Flashlight and any weapon he picks up is morphed to prevent violence. He seeks to help out who he deems worthy. 

Technically speaking hes a D-Class with godmode enabled or HP with the config option and spawns with the D-Class. After a X minute period set by the server he can open every door in the game. Also to make sure he is passive every weapon he picks up or spawns with is converted to a flashlight or something the server config can change. So people can know who he is, their rank is set to a red "SCP-343"


If you see how stuff can be improved don't feel afraid to send me a pm or submit a issue.
