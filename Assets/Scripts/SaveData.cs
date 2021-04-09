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
    public int highest_streak;
 
    public SaveData(Kernen_script kerne) {
        shield_level = Kernen_script.shield_level;
        speed_level = Kernen_script.speed_level;
        levels_unlocked = kerne.levels_unlocked;
        energy = Kernen_script.coins;
        highest_streak = Kernen_script.highest_streak;
    }


}
