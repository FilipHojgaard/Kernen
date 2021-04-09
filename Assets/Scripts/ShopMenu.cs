using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public UnityEngine.UI.Text energyAmountText;

    public UnityEngine.UI.Text current_shield;
    public UnityEngine.UI.Text next_shield;
    public UnityEngine.UI.Text next_shield_cost;


    public GameObject MainMenu;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        energyAmountText.text = "ENERGY: " + Kernen_script.coins;
        current_shield.text = "Shield: " + Kernen_script.shield_levels_effect[Kernen_script.shield_level];
        next_shield.text = "Next Shield: " + Kernen_script.shield_levels_effect[Kernen_script.shield_level + 1];
        next_shield_cost.text = "Cost: " + Kernen_script.shield_levels_cost[Kernen_script.shield_level + 1];
        Debug.Log(Kernen_script.coins);
    }

    public void Back() {
        MainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
