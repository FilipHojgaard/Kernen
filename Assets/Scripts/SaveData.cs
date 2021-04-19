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
    public bool bought_ability_reverse;
    public bool selected_ability_reverse;
 
    public SaveData(Kernen_script kerne) {
        shield_level = Kernen_script.shield_level;
        speed_level = Kernen_script.speed_level;
        levels_unlocked = Kernen_script.levels_unlocked;
        energy = Kernen_script.coins;
        highest_streak = Kernen_script.highest_streak;
        bought_ability_reverse = Kernen_script.bought_ability_reverse;
        selected_ability_reverse = Kernen_script.selected_ability_reverse;
    }


}
