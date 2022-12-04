using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public string target_1 = "n/a";
    public string target_2 = "n/a";
    public string target_3 = "n/a";
    public string target_4 = "n/a";
    public string target_5 = "n/a";

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collison)
    {
        
        if (collison.gameObject.tag == target_1 || collison.gameObject.tag == target_2 || collison.gameObject.tag == target_3 || collison.gameObject.tag == target_4 || collison.gameObject.tag == target_5)
        {
            Destroy(collison.gameObject);
        }

    }
}
