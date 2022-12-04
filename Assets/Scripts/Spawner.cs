using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject [] objectsToSpawn;
    Rigidbody2D playerObject;

    public float spawntime_maximum = 3.0f;
    public float spawntime = 0.0f;
    public Vector3 offset;

    void start()
    {
        playerObject = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collison)
    {
        
        if (collison.gameObject.tag == "Player")
        {
            spawntime = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {

        spawntime = spawntime - Time.deltaTime;

        if (spawntime <= 0)
        {
            int selection = Random.Range(0, objectsToSpawn.Length);

            Instantiate(objectsToSpawn[selection],transform.position, Quaternion.identity);

            spawntime = spawntime_maximum;

            transform.position = transform.position + offset;
        }
    }
}
