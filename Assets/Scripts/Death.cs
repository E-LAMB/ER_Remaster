using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{

    public int death_screen_location;

    void OnTriggerEnter2D(Collider2D collison)
    {
        
        if (collison.gameObject.tag == "Player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(death_screen_location);
        }

    }

}
