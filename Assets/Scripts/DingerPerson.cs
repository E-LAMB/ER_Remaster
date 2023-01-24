using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DingerPerson : MonoBehaviour
{

    public int success_requirement;
    public int actual_outcome;

    public GameObject to_summon;
    public GameObject self_g;
    public Transform self_t;

    // Start is called before the first frame update
    void Start()
    {
        actual_outcome = Random.Range(1,100);
        if (success_requirement < actual_outcome)
        {
            Instantiate(to_summon,self_t.position,self_t.rotation);
        } else
        {
            Destroy(self_g);
        }
    }


}
