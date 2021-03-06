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
    public UnityEngine.UI.Text shield_button_text;

    // SPEED
    public UnityEngine.UI.Text next_speed;
    public UnityEngine.UI.Text speed_button_text;

    // LEVELS
    public UnityEngine.UI.Text level_button_text;

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
        energyAmountText.text = Kernen_script.coins.ToString();
        // SHIELD LABELS
        if (Kernen_script.shield_level+1 < Kernen_script.shield_levels_effect.Length) {
            next_shield.text = "Upgrade Shield\n" + Kernen_script.shield_levels_effect[Kernen_script.shield_level] + " > " + Kernen_script.shield_levels_effect[Kernen_script.shield_level+1];
            shield_button_text.text = "Buy for " + Kernen_script.shield_levels_cost[Kernen_script.shield_level + 1];
        }
        else {
            next_shield.text = "Shield\n";
            shield_button_text.text = "Fully Upgraded!";
        }
        // SPEED LABELS
        if (Kernen_script.speed_level+1 < Kernen_script.speed_levels_effect.Length) {
            next_speed.text = "Upgrade Speed\n" + (Kernen_script.speed_level+1) + " > " + (Kernen_script.speed_level+2);
            speed_button_text.text = "Buy for " + Kernen_script.speed_levels_cost[Kernen_script.speed_level + 1];
        }
        else {
            next_speed.text = "Speed\n";
            speed_button_text.text = "Fully Upgraded!";
        }
        // LEVEL LABELS
        if (Kernen_script.levels_unlocked+1 < Kernen_script.level_cost.Length-1) {
            level_button_text.text = "Buy Level " + (Kernen_script.levels_unlocked+2) + " for " + Kernen_script.level_cost[Kernen_script.levels_unlocked + 1];
        }
        else {
            level_button_text.text = "You have every levels!";
        }
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
