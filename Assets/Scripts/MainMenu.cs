using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject shopMenu;
    
    public GameObject Spawner;
    public GameObject LevelLoader;
    public GameObject Kernen;


    // Start is called before the first frame update
    void Start()
    {
        Spawner.SetActive(false);
        LevelLoader.SetActive(false);
        Kernen.SetActive(false);
        Kernen.GetComponent<Kernen_script>().Reset();
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

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
