using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool spawn = true;

    public GameObject energy;
    public float spawn_delay = 5;
    public float spawn_chance = 70;

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

            Instantiate(energy, new Vector2(x, y), gameObject.transform.rotation);
        }

    }
}
