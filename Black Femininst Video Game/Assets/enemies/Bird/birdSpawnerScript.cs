using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdSpawnerScript : MonoBehaviour
{
    public GameObject player;
    public GameObject bird;
    private bool facingLeft;
    public Vector3 ySpawn;
    public Vector3 LeftRightAdj;//this is the vector we add to the spawner's position to make the bird come fro the left or right
    // Start is called before the first frame update
    private BoxCollider coll;
    void Start()
    {
        player = GameObject.Find("Player");
        coll = GetComponent<BoxCollider>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnBird();
            Debug.Log("The bird spawner touched the player");
        }
    }

    private void SpawnBird()
    {
        //randomize the Y of the spawn
        float yPos = Random.Range(-2f, 2f);

        //find out if the facingLeft is true
        if (player.transform.position.x < transform.position.x)
        {
            facingLeft = true;
        }
        else
        {
            facingLeft = false;
        }

        //set the LeftRigthAdj vector based on whether or not it's facing left or right
        if (facingLeft)
        {
            LeftRightAdj = new Vector3(15, Random.Range(0f, 4f), 0);
        }
        else
        {
            LeftRightAdj = new Vector3(-15, Random.Range(0f, 4f), 0);
        }

        //I'll let the bird orient itself on start
        Instantiate(bird, transform.position + LeftRightAdj, transform.rotation);

        //now disable the boox collider
        coll.enabled = false;

        //reenable the collider in Texas in case he crosses back over from the other side later
        Invoke("ReEnableCollider", 10);
    }

    private void ReEnableCollider()
    {
        coll.enabled = true;
    }
}
