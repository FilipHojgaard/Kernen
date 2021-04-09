using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public UnityEngine.UI.Text energyAmountText;
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
        Debug.Log(Kernen_script.coins);
    }

    public void Back() {
        MainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
