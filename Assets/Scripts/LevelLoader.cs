using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {
    public GameObject[] outer_rings = new GameObject[3];
    public GameObject[] mid_rings = new GameObject[3];
    public GameObject[] inner_rings = new GameObject[3];

    public bool load_outer_ring = true;
    public bool load_mid_ring = true;
    public bool load_inner_ring = true;

    public bool loadLevel = true;
    public GameObject spawner;
    Spawner spawner_script;
    // Start is called before the first frame update
    void Start()
    {
        spawner_script = spawner.GetComponent<Spawner>();
    }

    void removeRings() {
        GameObject[] all_rings = GameObject.FindGameObjectsWithTag("ring");
        for (int i = 0; i < all_rings.Length; i++) {
            Destroy(all_rings[i]);
        }
    }

    public void prepareLevel() {
        removeRings();
        if (Kernen_script.current_level == 0) {
            level1();
        }
        else if(Kernen_script.current_level == 1) {
            level2();
        }
        else if(Kernen_script.current_level == 2) {
            level3();
        }
        else if (Kernen_script.current_level == 3) {
            level4();
        }
        else if(Kernen_script.current_level == 4) {
            level5();
        }
        else if (Kernen_script.current_level == 5) {
            level6();
        }
    }

    void level1() {
        if (loadLevel) {
            load_inner_ring = false;
            load_mid_ring = true;
            load_outer_ring = false;

            int mid_ring_index = Random.Range(0, mid_rings.Length);

            if (load_mid_ring) {
                GameObject ring_mid = Instantiate(mid_rings[mid_ring_index], new Vector2(0, 0), gameObject.transform.rotation);
                Ring ring_mid_script = ring_mid.GetComponent<Ring>();
                ring_mid_script.clockwise = true;
                ring_mid_script.active_speed = Kernen_script.speed_levels_effect[Kernen_script.speed_level]*0.9f;
                ring_mid_script.cruise_speed = 10f;
            }

            spawner_script.spawn_chance = 100f;
            spawner_script.spawn_delay = 2.5f;
            spawner_script.red_energy_spawn = false;
            spawner_script.red_energy_change = 0f;
            spawner_script.reverse_energy_chance = 14f;
        }
    }

    void level2() {
        if (loadLevel) {
            load_inner_ring = true;
            load_mid_ring = false;
            load_outer_ring = false;

            int inner_ring_index = Random.Range(0, inner_rings.Length);

            if (load_inner_ring) {
                GameObject inner_ring = Instantiate(inner_rings[inner_ring_index], new Vector2(0, 0), gameObject.transform.rotation);
                Ring ring_inner_script = inner_ring.GetComponent<Ring>();
                ring_inner_script.clockwise = true;
                ring_inner_script.active_speed = Kernen_script.speed_levels_effect[Kernen_script.speed_level];
                ring_inner_script.cruise_speed = 13f;
            }

            spawner_script.spawn_chance = 100f;
            spawner_script.spawn_delay = 2.2f;
            spawner_script.red_energy_spawn = true;
            spawner_script.red_energy_change = 20f;
            spawner_script.reverse_energy_spawn = true;
            spawner_script.reverse_energy_chance = 14f;

        }
    }

    void level3() {
        if (loadLevel) {
            load_inner_ring = true;
            load_mid_ring = true;
            load_outer_ring = false;

            int mid_ring_index = Random.Range(0, mid_rings.Length);
            int inner_ring_index = Random.Range(0, inner_rings.Length);

            if (load_mid_ring) {
                GameObject ring_mid = Instantiate(mid_rings[mid_ring_index], new Vector2(0, 0), gameObject.transform.rotation);
                Ring ring_mid_script = ring_mid.GetComponent<Ring>();
                ring_mid_script.clockwise = false;
                ring_mid_script.active_speed = Kernen_script.speed_levels_effect[Kernen_script.speed_level];
                ring_mid_script.cruise_speed = 7f;
            }
            if (load_inner_ring) {
                GameObject ring_inner = Instantiate(inner_rings[inner_ring_index], new Vector2(0, 0), gameObject.transform.rotation);
                Ring ring_inner_script = ring_inner.GetComponent<Ring>();
                ring_inner_script.clockwise = true;
                ring_inner_script.active_speed = Kernen_script.speed_levels_effect[Kernen_script.speed_level];
                ring_inner_script.cruise_speed = 10f;
            }

            spawner_script.spawn_chance = 100f;
            spawner_script.spawn_delay = 2.7f;
            spawner_script.red_energy_spawn = true;
            spawner_script.red_energy_change = 20f;
            spawner_script.reverse_energy_spawn = true;
            spawner_script.reverse_energy_chance = 20f;

        }
    }

    void level4() {
        if (loadLevel) {
            load_inner_ring = true;
            load_mid_ring = true;
            load_outer_ring = true;

            int outer_ring_index = Random.Range(0, outer_rings.Length);
            int mid_ring_index = Random.Range(0, mid_rings.Length);
            int inner_ring_index = Random.Range(0, inner_rings.Length);

            if (load_outer_ring) {
                GameObject ring_outer = Instantiate(outer_rings[outer_ring_index], new Vector2(0, 0), gameObject.transform.rotation);
                Ring ring_outer_script = ring_outer.GetComponent<Ring>();
                ring_outer_script.clockwise = true;
                ring_outer_script.active_speed = Kernen_script.speed_levels_effect[Kernen_script.speed_level]*0.6f;
                ring_outer_script.cruise_speed = 5f;
            }
            if (load_mid_ring) {
                GameObject ring_mid = Instantiate(mid_rings[mid_ring_index], new Vector2(0, 0), gameObject.transform.rotation);
                Ring ring_mid_script = ring_mid.GetComponent<Ring>();
                ring_mid_script.clockwise = false;
                ring_mid_script.active_speed = Kernen_script.speed_levels_effect[Kernen_script.speed_level]*0.8f;
                ring_mid_script.cruise_speed = 7f;
            }
            if (load_inner_ring) {
                GameObject ring_inner = Instantiate(inner_rings[inner_ring_index], new Vector2(0, 0), gameObject.transform.rotation);
                Ring ring_inner_script = ring_inner.GetComponent<Ring>();
                ring_inner_script.clockwise = true;
                ring_inner_script.active_speed = Kernen_script.speed_levels_effect[Kernen_script.speed_level];
                ring_inner_script.cruise_speed = 10f;
            }

            spawner_script.spawn_chance = 100f;
            spawner_script.spawn_delay = 3.8f;
            spawner_script.red_energy_spawn = true;
            spawner_script.red_energy_change = 30f;
            spawner_script.reverse_energy_spawn = true;
            spawner_script.reverse_energy_chance = 35f;
        }
    }

    void level5() {
        if (loadLevel) {
            load_inner_ring = false;
            load_mid_ring = false;
            load_outer_ring = true;

            int outer_ring_index = Random.Range(0, outer_rings.Length);

            if (load_outer_ring) {
                GameObject ring_outer = Instantiate(outer_rings[outer_ring_index], new Vector2(0, 0), gameObject.transform.rotation);
                Ring ring_outer_script = ring_outer.GetComponent<Ring>();
                ring_outer_script.clockwise = true;
                ring_outer_script.active_speed = Kernen_script.speed_levels_effect[Kernen_script.speed_level]*0.6f;
                ring_outer_script.cruise_speed = 5f;
            }

            spawner_script.spawn_chance = 50f;
            spawner_script.spawn_delay = 1f;
            spawner_script.red_energy_spawn = true;
            spawner_script.red_energy_change = 90;
            spawner_script.reverse_energy_spawn = true;
            spawner_script.reverse_energy_chance = 10f;
        }
    }

    void level6() {
        if (loadLevel) {
            load_inner_ring = true;
            load_mid_ring = false;
            load_outer_ring = true;

            int inner_ring_index = Random.Range(0, inner_rings.Length);
            int outer_ring_index = Random.Range(0, outer_rings.Length);

            if (load_inner_ring) {
                GameObject ring_inner = Instantiate(inner_rings[inner_ring_index], new Vector2(0, 0), gameObject.transform.rotation);
                Ring ring_inner_script = ring_inner.GetComponent<Ring>();
                ring_inner_script.clockwise = true;
                ring_inner_script.active_speed = Kernen_script.speed_levels_effect[Kernen_script.speed_level] *0.9f;
                ring_inner_script.cruise_speed = 5;
            }
            if (load_outer_ring) {
                GameObject ring_outer = Instantiate(outer_rings[outer_ring_index], new Vector2(0, 0), gameObject.transform.rotation);
                Ring ring_outer_script = ring_outer.GetComponent<Ring>();
                ring_outer_script.clockwise = true;
                ring_outer_script.active_speed = Kernen_script.speed_levels_effect[Kernen_script.speed_level]*0.6f;
                ring_outer_script.cruise_speed = 8f;
            }

            spawner_script.spawn_chance = 20f;
            spawner_script.spawn_delay = 0.4f;
            spawner_script.red_energy_spawn = true;
            spawner_script.red_energy_change = 15;
            spawner_script.reverse_energy_spawn = true;
            spawner_script.reverse_energy_chance = 12f;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
