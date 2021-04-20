using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool spawn = true;

    public GameObject energy;
    public GameObject red_energy;
    public GameObject reverse_energy;
    public float spawn_delay = 5f;
    public float spawn_chance = 70f;

    public bool red_energy_spawn;
    public float red_energy_change = 10f;

    public bool reverse_energy_spawn;
    public float reverse_energy_chance = 10f;

    float y_min = -4;
    float y_max = 4;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawn){
            return;
        }
        timer += Time.deltaTime;
        if (timer >= spawn_delay) {
            Spawn();
            timer = 0f;
        }


    }

    void Spawn() {
        float spawn_dice_roll = Random.Range(0, 100);
        if (spawn_dice_roll <= spawn_chance) {
            // Find x position
            float x = Random.Range(1, 3);
            if (x == 1) {
                x = -10;
            }
            else {
                x = 10;
            }
            // Find y position
            float y = Random.Range(y_min, y_max);

            float other_spawn = Random.Range(0f, 100f);
            Debug.Log(other_spawn);
            if (red_energy_spawn) {
                if (other_spawn <= red_energy_change) {
                    Instantiate(red_energy, new Vector2(x, y), gameObject.transform.rotation);
                    return;
                }
            }if (reverse_energy_spawn) {
                if (other_spawn <= (reverse_energy_chance + reverse_energy_chance)) {
                    Instantiate(reverse_energy, new Vector2(x, y), gameObject.transform.rotation);
                    return;
                }
            }
            Instantiate(energy, new Vector2(x, y), gameObject.transform.rotation);
        }

    }
}
