using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Kernen_script : MonoBehaviour
{
    public GameObject mainMenu;

    int points = 0;
    public static int coins = 0;
    public static int highscore = 0;
    int streak = 0;

    // SHIELD
    int max_shield_integrety = 100;
    int shield_integrety;
    public int shield_level = 0;
    int[] shield_levels_cost = { 0, 50, 120, 300, 500, 1000, 3000};
    int[] shield_levels_effect = {100, 150, 300, 450, 600, 750, 1000 };

    // SPEED
    public int speed_level;
    int[] speed_levels_cost = { 0, 100, 200, 400, 800, 1200, 1500 };
    int[] speed_levels_effect = {60, 65, 70, 75, 80, 85, 90};

    // LEVELS
    public int levels_unlocked = 1;

    public AudioSource energy_collected_sfx;
    public AudioSource energy_collected_5_sfx;
    // Start is called before the first frame update
    void Start()
    {
        shield_integrety = shield_levels_effect[shield_level];
        if (File.Exists(Application.persistentDataPath + "/savedData.ker")) {
            loadGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((shield_integrety <= 0) || (Input.GetKey(KeyCode.Escape))){
            mainMenu.GetComponent<MainMenu>().restart();
            Reset();
            saveGame();
        }

    }

    public void Reset() {
        shield_integrety = shield_levels_effect[shield_level];
        points = 0;
        streak = 0;
        GameObject[] all_energy = GameObject.FindGameObjectsWithTag("energy");
        for (int i = 0; i < all_energy.Length; i++) {
            Destroy(all_energy[i]);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("energy")) {
            Destroy(other.gameObject);

            int pts;

            if (streak >= 5) {
                energy_collected_5_sfx.Play();
                pts = 2;
            }
            else {
                energy_collected_sfx.Play();
                pts = 1;
            }
            points += pts;
            streak += pts;
            coins += pts;
            Debug.Log("STREAK: " + streak);
        }
    }


    public void shield_damage(int dmg) {
        shield_integrety -= dmg;
        Debug.Log("SHIELD INTEGRETY: " + shield_integrety);
        streak = 0;
    }

    public void saveGame() {
        SaveSystem.SaveGame(this);
    }

    public void loadGame() {
        SaveData data = SaveSystem.LoadGame();
        shield_level = data.shield_level;
        speed_level = data.speed_level;
        levels_unlocked = data.levels_unlocked;
        coins = data.energy;
    }
}
