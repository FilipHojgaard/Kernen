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
    // Start is called before the first frame update
    void Start()
    {
        if (loadLevel) {
            int outer_ring_index = Random.Range(0, outer_rings.Length);
            int mid_ring_index = Random.Range(0, mid_rings.Length);
            int inner_ring_index = Random.Range(0, inner_rings.Length);

            if (load_outer_ring) {
                Instantiate(outer_rings[outer_ring_index], new Vector2(0, 0), gameObject.transform.rotation);
            }
            if (load_mid_ring) {
                Instantiate(mid_rings[mid_ring_index], new Vector2(0, 0), gameObject.transform.rotation);
            }
            if (load_inner_ring) {
                Instantiate(inner_rings[inner_ring_index], new Vector2(0, 0), gameObject.transform.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
