using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int shield_level;
    public int speed_level;
    public int levels_unlocked;
    public int energy;
 
    public SaveData(Kernen_script kerne) {
        shield_level = kerne.shield_level;
        speed_level = kerne.speed_level;
        levels_unlocked = kerne.levels_unlocked;
        energy = Kernen_script.coins;
    }


}
