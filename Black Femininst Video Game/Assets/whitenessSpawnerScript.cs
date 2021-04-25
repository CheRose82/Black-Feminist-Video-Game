using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whitenessSpawnerScript : MonoBehaviour
{
    public float spawnRate;
    public bool spawning;
    public int whichImage;
    public GameObject currentImage;

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;
    public GameObject p6;
    public GameObject p7;
    public GameObject p8;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 1f;
        spawning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawning)
        {
            spawnRate -= Time.deltaTime;
            if(spawnRate < 0)
            {
                ChooseAndSpawn();
            }
        }
    }

    public void ChooseAndSpawn()
    {

        //random selection of an image
        whichImage = Random.Range(1, 9);
        if (whichImage == 1)
        {
            currentImage = p1;
        } else if (whichImage == 2)
        {
            currentImage = p2;
        } else if (whichImage == 3)
        {
            currentImage = p3;
        } else if (whichImage == 4)
        {
            currentImage = p4;
        } else if (whichImage == 5)
        {
            currentImage = p5;
        }else if(whichImage == 6)
        {
            currentImage = p6;
        } else if(whichImage == 7)
        {
            currentImage = p7;
        }
        else
        {
            currentImage = p8;
        }

        //
        Instantiate(currentImage, transform.position, Quaternion.identity);
    }
}
