using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    // ENERGY
    public UnityEngine.UI.Text energyAmountText;

    // SHIELD
    public UnityEngine.UI.Text next_shield;
    public UnityEngine.UI.Text next_shield_cost;
    public UnityEngine.UI.Text current_shield_level;
    public UnityEngine.UI.Text current_shield;

    // SPEED
    public UnityEngine.UI.Text next_speed;
    public UnityEngine.UI.Text next_speed_cost;
    public UnityEngine.UI.Text current_speed_level;
    public UnityEngine.UI.Text current_speed;

    // LEVELS
    public UnityEngine.UI.Text next_level;
    public UnityEngine.UI.Text next_level_cost;
    public UnityEngine.UI.Text current_level;

    // Abilities
    public UnityEngine.UI.Text reverseText;

    public GameObject MainMenu;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // ENERGY LABELS
        energyAmountText.text = "ENERGY: " + Kernen_script.coins;
        // SHIELD LABELS
        next_shield.text = "Next Shield: " + Kernen_script.shield_levels_effect[Kernen_script.shield_level + 1];
        next_shield_cost.text = "Cost: " + Kernen_script.shield_levels_cost[Kernen_script.shield_level + 1];
        current_shield_level.text = "Shield Level: " + (Kernen_script.shield_level+1);
        current_shield.text = "Shield: " + Kernen_script.shield_levels_effect[Kernen_script.shield_level];
        // SPEED LABELS
        next_speed.text = "Next Speed:" + Kernen_script.speed_levels_effect[Kernen_script.speed_level+1];
        next_speed_cost.text = "Cost: " + Kernen_script.speed_levels_cost[Kernen_script.speed_level + 1];
        current_speed_level.text = "Speed Level: " + (Kernen_script.speed_level + 1);
        current_speed.text = "Speed: " + Kernen_script.speed_levels_effect[Kernen_script.speed_level];
        // LEVEL LABELS
        next_level.text = "Next Level: " + (Kernen_script.levels_unlocked + 2);
        next_level_cost.text = "Cost: " + Kernen_script.level_cost[Kernen_script.levels_unlocked+1];
        current_level.text = "At Level: " + (Kernen_script.levels_unlocked+1);
        // Abilities
        if (!Kernen_script.bought_ability_reverse) {
            reverseText.text = "Buy Reverse: " + Kernen_script.reverse_cost;
        }else if (!Kernen_script.selected_ability_reverse) {
            reverseText.text = "Use Reverse";
        }
        else {
            reverseText.text = "Using Reverse";
        }
    }

    public void Back() {
        MainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
