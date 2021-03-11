using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NicoleNPCScript : MonoBehaviour
{
    public GameObject player;
    public bool activated;
    public float distanceToPlayer;
    public float walkActivateDistance;
    public float speed;
    public bool walking;
    public float idleTimer = 3.0f;
    public bool waitingToIdle;

    //for animation
    public GameObject sprite;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        speed = .05f;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            //if the player gets too far away from Nicole, then Nicole walking activates
            if (distanceToPlayer > walkActivateDistance)
            {
                walking = true;
                anim.SetBool("Running", true);
                anim.SetBool("Idling", false);
                waitingToIdle = false;
                idleTimer = 3.0f;
            }
            else
            {
                walking = false;
                anim.SetBool("Running", false);
                anim.SetBool("Idling", true);
                waitingToIdle = true;
            }

            if (waitingToIdle == true)
            {
                idleTimer -= Time.deltaTime;
            }
            if (idleTimer < 0)
            {
                anim.SetTrigger("JumpTrigger");
            }

            if (walking == true)
            {
                if (transform.position.x < player.transform.position.x)
                {
                    transform.Translate(speed, 0, 0);
                }
                else
                {
                    transform.Translate(-speed, 0, 0);
                }
            }
        }
        
    }
}
