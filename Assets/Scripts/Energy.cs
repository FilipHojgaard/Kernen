using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public GameObject Kernen;
    Rigidbody2D body;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate() {
        Vector2 lookDir = Kernen.GetComponent<Rigidbody2D>().position - body.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f;
        body.rotation = angle;
        body.velocity = body.transform.up * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }




}
