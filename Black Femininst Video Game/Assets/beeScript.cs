using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeScript : MonoBehaviour
{
    public bool activated;
    public float moveSpeed;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(activated == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
    }

    public void BeeSwarm()
    {
        activated = true;
    }
}
