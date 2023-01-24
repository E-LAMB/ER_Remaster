using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{

    public Transform self;
    public float ground_position;

    public bool scored;

    public int to_award = 0;
    public float award_timer;
    float time_max = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (self.position.y < ground_position && !scored)
        {
            scored = true;
            to_award = 20;
        }

        if (to_award > 0)
        {
            award_timer += Time.deltaTime;
            if (award_timer >= time_max)
            {
                Tracker.score += 1;
                to_award -= 1;
                award_timer = 0f;
            }
        }
    }
}
