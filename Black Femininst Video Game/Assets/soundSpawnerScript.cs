using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundSpawnerScript : MonoBehaviour
{
    public GameObject soundPart;
    public float spawnRate;
    public GameObject player;
    public bool activated;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(activated == true)
        {
            spawnRate -= Time.deltaTime;

            if (spawnRate < 0)
            {
                Instantiate(soundPart, transform.position, transform.rotation);
                spawnRate = 1.0f;
            }

        }

    }
}
