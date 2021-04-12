using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Kernen_script : MonoBehaviour
{
    public GameObject mainMenu;

    int points = 0;
    public static int coins = 5000;
    public static int highscore = 0;
    public static int highest_streak;
    int streak = 0;

    // SHIELD
    int max_shield_integrety = 100;
    int shield_integrety;
    public static int shield_level = 0;
    public static int[] shield_levels_cost = { 0, 50, 120, 300, 500, 1000, 3000};
    public static int[] shield_levels_effect = {60, 100, 180, 230, 300, 400, 600 };

    // SPEED
    public static int speed_level;
    public static int[] speed_levels_cost = { 0, 100, 200, 400, 800, 1200, 1500 };
    public static int[] speed_levels_effect = {40, 48, 55, 63, 70, 85, 90};

    // LEVELS
    public static int levels_unlocked = 1;
    public static int current_level = 1;
    public static int[] level_cost = { 0, 150, 400, 800, 1500 };

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

    public void buy_shield_upgrade() {
        if (coins >= shield_levels_cost[shield_level + 1]) {
            coins -= shield_levels_cost[shield_level + 1];
            shield_level++;
        }
    }

    public void buy_speed_upgrade() {
        if (coins >= speed_levels_cost[speed_level + 1]) {
            coins -= speed_levels_cost[speed_level + 1];
            speed_level++;
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
            if (streak > highest_streak) {
                highest_streak = streak;
            }
            Debug.Log("STREAK: " + streak);
        }
    }


    public void shield_damage(int dmg) {
        shield_integrety -= dmg;
        Debug.Log("SHIELD INTEGRETY: " + shield_integrety);
        streak = 0;
    }

    public void increaseLevel() {
        Debug.Log(current_level);
        if (levels_unlocked > current_level) {
            current_level++;
            Debug.Log(current_level);
        }
    }
    public void decreaseLevel() {
        Debug.Log(current_level);
        if (current_level > 1) {
            current_level--;
            Debug.Log(current_level);
        }
    }

    public void buyLevel() {
        if (coins >= level_cost[current_level + 1]) {
            coins -= level_cost[current_level + 1];
            levels_unlocked++;
            current_level = levels_unlocked;
        }
    }

    public void saveGame() {
        SaveSystem.SaveGame(this);
    }


    public void loadGame() {
        if (File.Exists(Application.persistentDataPath + "/savedData.ker")) {
            SaveData data = SaveSystem.LoadGame();
            shield_level = data.shield_level;
            speed_level = data.speed_level;
            levels_unlocked = data.levels_unlocked;
            coins = data.energy;
            highest_streak = data.highest_streak;
        }
    }
}
