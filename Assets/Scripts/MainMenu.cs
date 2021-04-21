using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject shopMenu;
    public GameObject abilityUI;
    
    public GameObject Spawner;
    public GameObject LevelLoader;
    public GameObject Kernen;

    public UnityEngine.UI.Text highest_streak;

    public UnityEngine.UI.Text currentLevel;

    public GameObject shieldbar;

    // Start is called before the first frame update
    void Start()
    {
        SaveSystem.LoadGame();
        restart();
        Spawner.SetActive(false);
        LevelLoader.SetActive(false);
        shieldbar.SetActive(false);
        abilityUI.SetActive(false);
        //Kernen.SetActive(false);
        Kernen.GetComponent<Kernen_script>().Reset();
        gameObject.SetActive(true);
        highest_streak.text = "Highest Streak: " + Kernen_script.highest_streak;
    }

    // Update is called once per frame
    void Update()
    {
        highest_streak.text = "Highest Streak: " + Kernen_script.highest_streak;
        currentLevel.text = "Level " + (Kernen_script.current_level+1);
    }

    public void restart() {
        Spawner.SetActive(false);
        LevelLoader.SetActive(false);
        //Kernen.SetActive(false);
        gameObject.SetActive(true);
        abilityUI.SetActive(false);
        shieldbar.SetActive(false);
    }

    public void PlayButton() {
        Spawner.SetActive(true);
        LevelLoader.SetActive(true);
        //Kernen.SetActive(true);
        gameObject.SetActive(false);
        shieldbar.SetActive(true);
        if(Kernen_script.bought_ability_reverse && Kernen_script.selected_ability_reverse) {
            abilityUI.SetActive(true);
        }
    }

    public void ShopButton() {
        shopMenu.SetActive(true);
        abilityUI.SetActive(false);
        gameObject.SetActive(false);
        shieldbar.SetActive(false);
    }

    public void ExitButton() {
        Application.Quit();
    }
}
