using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{


    Rigidbody2D body;

    public float cruise_speed = 10f;
    public float active_speed = 60f;
    public bool clockwise = true;
    private float direction;
    private bool active = false;

    GameObject kernen_obj;

    public AudioSource shield_hit_sfx;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        Debug.Log("RING STARTET");
    }

    void FixedUpdate() {
        if (active) {
            body.rotation -= active_speed * direction * Time.deltaTime;
        }
        else {
            body.rotation -= cruise_speed * direction * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check for clockwise direction
        if (clockwise) {direction = 1f;}else{direction = -1f;}
        
        // Press space or touch screen
        if (Input.GetKey(KeyCode.Space)) {active = true;}else {active = false;}


    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("energy")) {
            kernen_obj = GameObject.Find("kernen");
            Destroy(other.gameObject);
            kernen_obj.GetComponent<Kernen_script>().shield_damage(20);
            shield_hit_sfx.Play();
        }
    }
}
