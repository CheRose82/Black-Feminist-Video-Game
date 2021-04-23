using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class womenVoicesParticleScript : MonoBehaviour
{
    public GameObject player;
    private float deathTimer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        transform.parent = player.transform;
        deathTimer = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        deathTimer -= Time.deltaTime;
        if(deathTimer < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
