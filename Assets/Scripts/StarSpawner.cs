using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{

    public GameObject star;

    public Transform self;
    public float x_pos;
    public LayerMask player_layer;

    // Start is called before the first frame update
    void Start()
    {
        DoSpawn(); DoSpawn(); DoSpawn(); DoSpawn(); DoSpawn();
        DoSpawn(); DoSpawn(); DoSpawn(); DoSpawn(); DoSpawn();
        DoSpawn(); DoSpawn(); DoSpawn(); DoSpawn(); DoSpawn();
    }

    void DoSpawn()
    {
        x_pos += Random.Range(-0.5f,6f);
        self.position = new Vector3(x_pos, Random.Range(20f, -10f), 15f);
        Instantiate(star, self.position, self.localRotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(gameObject.transform.position, 40f, player_layer))
        {
            x_pos += Random.Range(-0.5f,6f);
            self.position = new Vector3(x_pos, Random.Range(20f, -10f), 15f);
            Instantiate(star, self.position, self.localRotation);
        }
    }
}
