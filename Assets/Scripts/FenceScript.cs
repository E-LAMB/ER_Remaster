using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceScript : MonoBehaviour
{

    Rigidbody2D my_rigid;
    public LayerMask player_layer;
    //bool knocked;

    // Start is called before the first frame update
    void Start()
    {
        my_rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Tracker.player_dashing && my_rigid.IsTouchingLayers(player_layer))
        {
            //knocked = true;
            my_rigid.constraints = RigidbodyConstraints2D.None;

        } 
        //else
        //{
        //    my_rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        //}

    }
}
