using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform subject;
    public Transform self;
    public Vector3 offset;
    public Vector3 final_position;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            Tracker.score += 1;
            timer = 0f;
        }

        final_position = subject.position + offset;   
        if (final_position.y < -5)
        {
            final_position.y = -5;
        }
        self.position = final_position;
    }
}
