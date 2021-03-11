using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdScript : MonoBehaviour
{
    public GameObject player;
    Rigidbody rb;
    public int AI_behavior;

    public float speed = 1.0f;

    private float attackRange;
    private float distanceToPlayer;
    public Transform target;
    private Vector3 straightAngle;
    private float riseUpSpeed;//the speed at which the bird rises after attacking
    //variables for Sine movement
    //public float verticalMagnitude = 0.5f;
    //public float verticalFrequency = 10.0f;
    //public float yPos;
    
    //AI_behaviors
    // 1 = flyign towards the player
    // 2 = orient towards the player, pause for a second before diving
    // 3 = fly towards the player
    //  4 = fly away and luft up after attackgin player
    // 5 = destroy

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        //orient the bird to face the player
        if(player.transform.position.x < transform.position.x)
        {
            transform.localEulerAngles = new Vector3(0, -90, 0);
        } else
        {
            transform.localEulerAngles = new Vector3(0, 90, 0);
        }
        straightAngle = transform.localEulerAngles;

        AI_behavior = 1;

        attackRange = Random.Range(7f, 10f);
        target = GameObject.Find("Player").transform;
        riseUpSpeed = 0.03f;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distanceToPlayer = Mathf.Abs(Vector3.Distance(transform.position, player.transform.position));

        if(AI_behavior == 1)//basically just move forward until he gets close enough the player
        {
            //move forward
            rb.velocity = transform.forward * speed;
            //go up and down like he's fling. Maybe hold off on that for now.

            //if the bird gets close enough orient and then start the kamakazi
            if(Mathf.Abs(Vector3.Distance(player.transform.position, transform.position)) < attackRange)
            {
                AI_behavior = 2;
            }
        }

        //orient yourself towards the player
        if(AI_behavior == 2)
        {
            transform.LookAt(target);
            //aim it down just a little bit more so that it aims at the feet. works either side
            //i may decide to have it aim down even further and then slowly pull up\
            transform.Rotate(5, 0, 0);
            //rb.useGravity = true;
            rb.velocity = Vector3.zero;
            Invoke("GoToAI_Behavior3", 1.0f);
        }

        //fly forward until...
        if(AI_behavior == 3)
        {
            rb.velocity = transform.forward * speed;
            if (Vector3.Distance(player.transform.position, transform.position) < 0.5f)
            {
                //turn the bird to face straight again
                transform.localEulerAngles = straightAngle;
                AI_behavior = 4;//trigger the animation first
            }
        }

        //fly forward and away.
        if(AI_behavior == 4)
        {
            rb.velocity = transform.forward * speed * 1.5f;
            transform.Translate(0, riseUpSpeed, 0);
            riseUpSpeed = +0.045f;
            if(Vector3.Distance(player.transform.position, transform.position) > 10f)
            {
                AI_behavior = 5;
            }
        }

        if(AI_behavior == 5)
        {
            //Debug.Log("The bird is dead");
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //turn the bird stragith again
            transform.localEulerAngles = straightAngle;
            //do THIS if it touches the player
            AI_behavior = 4;//trigger the animation first
        }

        if (other.CompareTag("Ground"))
        {
            // do THIS if it thenn touches the ground
            //fly straight a bit, then go back up.
        }
    }

    void GoToAI_Behavior3()
    {
        AI_behavior = 3;
    }
}
