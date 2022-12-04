using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    public float moving_speed = 1000f;
    Rigidbody2D moving_object; 

    // Start is called before the first frame update
    void Start()
    {
        moving_object = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moving_object.velocity = new Vector2 (moving_speed * Time.deltaTime,0);
    }
}
