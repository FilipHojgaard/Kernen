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
    }

    void level1() {
        if (loadLevel) {
            load_inner_ring = true;
            load_mid_ring = true;
            load_outer_ring = false;

            int mid_ring_index = Random.Range(0, mid_rings.Length);
            int inner_ring_index = Random.Range(0, inner_rings.Length);

            if (load_mid_ring) {
                GameObject ring_mid = Instantiate(mid_rings[mid_ring_index], new Vector2(0, 0), gameObject.transform.rotation);
                Ring ring_mid_script = ring_mid.GetComponent<Ring>();
                ring_mid_script.clockwise = true;
                ring_mid_script.active_speed = Kernen_script.speed_levels_effect[Kernen_script.speed_level];
                ring_mid_script.cruise_speed = 10f;
            }
            if (load_inner_ring) {
                GameObject inner_ring = Instantiate(inner_rings[inner_ring_index], new Vector2(0, 0), gameObject.transform.rotation);
                Ring ring_inner_script = inner_ring.GetComponent<Ring>();
                ring_inner_script.clockwise = false;
                ring_inner_script.active_speed = Kernen_script.speed_levels_effect[Kernen_script.speed_level]*0.95f;
                ring_inner_script.cruise_speed = 10f;
            }

            spawner_script.spawn_chance = 100f;
            spawner_script.spawn_delay = 3.5f;
        }
    }

    void level2() {
        if (loadLevel) {
            int inner_ring_index = Random.Range(0, inner_rings.Length);

            if (load_inner_ring) {
                GameObject inner_ring = Instantiate(inner_rings[inner_ring_index], new Vector2(0, 0), gameObject.transform.rotation);
                Ring ring_inner_script = inner_ring.GetComponent<Ring>();
                ring_inner_script.clockwise = true;
                ring_inner_script.active_speed = Kernen_script.speed_levels_effect[Kernen_script.speed_level];
                ring_inner_script.cruise_speed = 10f;
            }

            spawner_script.spawn_chance = 100f;
            spawner_script.spawn_delay = 1.2f;
        }
    }

    void level3() {
        if (loadLevel) {
            load_inner_ring = true;
            load_mid_ring = true;
            load_outer_ring = true;

            int outer_ring_index = Random.Range(0, outer_rings.Length);
            int mid_ring_index = Random.Range(0, mid_rings.Length);
            int inner_ring_index = Random.Range(0, inner_rings.Length);

            if (load_outer_ring) {
                GameObject ring_outer = Instantiate(outer_rings[outer_ring_index], new Vector2(0, 0), gameObject.transform.rotation);
                ring_outer.GetComponent<Ring>().clockwise = true;
            }
            if (load_mid_ring) {
                GameObject ring_mid = Instantiate(mid_rings[mid_ring_index], new Vector2(0, 0), gameObject.transform.rotation);
                ring_mid.GetComponent<Ring>().clockwise = false;
            }
            if (load_inner_ring) {
                GameObject ring_inner = Instantiate(inner_rings[inner_ring_index], new Vector2(0, 0), gameObject.transform.rotation);
                ring_inner.GetComponent<Ring>().clockwise = true;
            }

            spawner_script.spawn_chance = 100f;
            spawner_script.spawn_delay = 4f;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
