using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Kernen_script : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject sfx_manager;
    public Shieldbar shieldbar;

    int points = 0;
    public static int coins = 10000;
    public static int highscore = 0;
    public static int highest_streak;
    int streak = 0;

    // SHIELD
    int max_shield_integrety = 100;
    int shield_integrety;
    public static int shield_level = 0;
    public static int[] shield_levels_cost = { 0, 20, 100, 300, 500, 1000, 3000};
    public static int[] shield_levels_effect = {40, 80, 130, 200, 250, 300, 400};

    // SPEED
    public static int speed_level = 0;
    public static int[] speed_levels_cost = { 0, 10, 25, 50, 150, 200, 400};
    public static int[] speed_levels_effect = {18, 22, 28, 35, 40, 45, 50};

    // LEVELS
    public static int levels_unlocked = 0;
    public static int current_level = 0;
    public static int[] level_cost = { 0, 50, 120, 300, 500, 700, 1000, 2000};

    // COIN GAINS
    public static int[] coin_gains_for_level = {1, 2, 3, 4, 5, 6};

    public AudioSource energy_collected_sfx;
    public AudioSource energy_collected_5_sfx;

    // ABILITIES
    public static float ability_cooldown = 0f;
    //reverse
    public static bool bought_ability_reverse = false;
    public static bool selected_ability_reverse = false;
    public static int available_ability_reverse = 0;
    public static bool ability_reverse_active = false;
    public static int reverse_cost = 999;


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
        shieldbar.setMaxShield(shield_integrety);
        shieldbar.setShield(shield_integrety);
        points = 0;
        streak = 0;
        GameObject[] all_energy = GameObject.FindGameObjectsWithTag("energy");
        for (int i = 0; i < all_energy.Length; i++) {
            Destroy(all_energy[i]);
        }
        GameObject[] all_red_energy = GameObject.FindGameObjectsWithTag("red_energy");
        for (int i = 0; i < all_red_energy.Length; i++) {
            Destroy(all_red_energy[i]);
        }
        GameObject[] all_reverse_energy = GameObject.FindGameObjectsWithTag("reverse_energy");
        for (int i = 0; i < all_reverse_energy.Length; i++) {
            Destroy(all_reverse_energy[i]);
        }
        sfx_manager.GetComponent<sfx_manager_script>().stop_ambient_music();
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
            energy_collect(true);

        }
        else if (other.CompareTag("red_energy")) {
            Destroy(other.gameObject);
            shield_damage(50);
            Debug.Log("RED ENERGY HIT");
            sfx_manager.GetComponent<sfx_manager_script>().play_shield_hit_sfx();
        }
        else if (other.CompareTag("reverse_energy")) {
            Destroy(other.gameObject);
            available_ability_reverse++;
            energy_collect(false);
            sfx_manager.GetComponent<sfx_manager_script>().play_pickup_blue_sfx();
        }
    }

    public void energy_collect(bool play_sound) {
        int gained_coins;

        if (streak >= 5) {
            if (play_sound) {
                energy_collected_5_sfx.Play();
            }
            gained_coins = coin_gains_for_level[current_level] * 2;
        }
        else {
            if (play_sound) {
                energy_collected_sfx.Play();
            }
            gained_coins = coin_gains_for_level[current_level];
        }
        points++;
        streak++;
        coins += gained_coins;
        if (streak > highest_streak) {
            highest_streak = streak;
        }
        if (points % 5 == 0) {
            coins += coin_gains_for_level[current_level];
            // SCREEN SPLASH EFFECT FOR EVERY 5 Coins.
        }
        Debug.Log("STREAK: " + streak);
    }

    public void shield_damage(int dmg) {
        shield_integrety -= dmg;
        shieldbar.setShield(shield_integrety);
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
        if (current_level > 0) {
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

    public void buy_or_select_reverse() {
        if (!bought_ability_reverse && coins >= reverse_cost) {
            coins -= reverse_cost;
            bought_ability_reverse = true;
            selected_ability_reverse = true;
        }else if(bought_ability_reverse) {
            selected_ability_reverse = !selected_ability_reverse;
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
            bought_ability_reverse = data.bought_ability_reverse;
            selected_ability_reverse = data.selected_ability_reverse;
        }
    }
}
