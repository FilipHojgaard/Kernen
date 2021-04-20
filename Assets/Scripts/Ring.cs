using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{


    Rigidbody2D body;

    public float cruise_speed;
    public float active_speed;
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
            body.rotation -= Kernen_script.speed_levels_effect[Kernen_script.speed_level] * direction * Time.deltaTime;
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

        // Check for ability cooldowns
        if (Kernen_script.ability_cooldown > 0f) {
            Kernen_script.ability_cooldown -= Time.deltaTime;
        }
        else if(Kernen_script.ability_cooldown < 0f) {
            Kernen_script.ability_reverse_active = false;
            Kernen_script.ability_cooldown = 0f;
        }
        // Press space or touch screen
        if (Input.GetKey(KeyCode.Space) || Input.touchCount == 1) {
            Debug.Log("SPACE");
            active = true;
        }


        else if (Input.GetKey(KeyCode.A) || Input.touchCount == 2) {
            if (Kernen_script.bought_ability_reverse && Kernen_script.selected_ability_reverse && Kernen_script.available_ability_reverse > 0 && !Kernen_script.ability_reverse_active) {
                Kernen_script.available_ability_reverse -= 1;
                Kernen_script.ability_reverse_active = true;
                Kernen_script.ability_cooldown = 2f;
                direction *= -1f;
                active = true;
            }
            if (Kernen_script.bought_ability_reverse && Kernen_script.selected_ability_reverse && Kernen_script.ability_reverse_active && Kernen_script.ability_cooldown > 0f) {
                direction *= -1f;
                active = true;
            }
                //Kernen_script.available_ability_reverse = false;
        }
        else {
            active = false;
        }

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("energy") || other.CompareTag("reverse_energy")) {
            kernen_obj = GameObject.Find("kernen");
            Destroy(other.gameObject);
            kernen_obj.GetComponent<Kernen_script>().shield_damage(20);
            shield_hit_sfx.Play();
        }
        else if (other.CompareTag("red_energy")) {
            kernen_obj = GameObject.Find("kernen");
            Destroy(other.gameObject);
            kernen_obj.GetComponent<Kernen_script>().energy_collect();
        }
    }
}
