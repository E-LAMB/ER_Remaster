using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverDeathBarrier : MonoBehaviour
{

    public float speed_up_timer = 0f;
    public float speed_up_timer_max = 0f;
    public float speed_up_timer_addon = 0.5f;
    public float speed_up_amount = 200f;

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

        if (speed_up_timer <= 0f)
        {
            speed_up_timer_max = speed_up_timer_max + speed_up_timer_addon;
            speed_up_timer = speed_up_timer_max;
            moving_speed = moving_speed + speed_up_amount;
        }

        moving_object.velocity = new Vector2 (moving_speed * Time.deltaTime,0);

        speed_up_timer = speed_up_timer - Time.deltaTime;
        
    }
}
