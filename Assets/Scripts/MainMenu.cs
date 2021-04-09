using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject shopMenu;
    
    public GameObject Spawner;
    public GameObject LevelLoader;
    public GameObject Kernen;

    public UnityEngine.UI.Text highest_streak;


    // Start is called before the first frame update
    void Start()
    {
        SaveSystem.LoadGame();
        restart();
        Spawner.SetActive(false);
        LevelLoader.SetActive(false);
        Kernen.SetActive(false);
        Kernen.GetComponent<Kernen_script>().Reset();
        gameObject.SetActive(true);
        highest_streak.text = "Highest Streak: " + Kernen_script.highest_streak;
    }

    // Update is called once per frame
    void Update()
    {
        highest_streak.text = "Highest Streak: " + Kernen_script.highest_streak;
    }

    public void restart() {
        Spawner.SetActive(false);
        LevelLoader.SetActive(false);
        Kernen.SetActive(false);
        gameObject.SetActive(true);
    }

    public void PlayButton() {
        Spawner.SetActive(true);
        LevelLoader.SetActive(true);
        Kernen.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ShopButton() {
        shopMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ExitButton() {
        Application.Quit();
    }
}
