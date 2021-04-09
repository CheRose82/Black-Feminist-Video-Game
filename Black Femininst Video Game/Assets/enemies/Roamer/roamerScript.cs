using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roamerScript : MonoBehaviour
{
    Rigidbody rb;
    public GameObject player;
    public GameObject front;
    public GameObject projectile;
    public GameObject deathExpl;
    public float distanceToPlayer;
    public float walkSpeed;
    public bool activated;
    public Vector3 nextPos;
    private float groundHeight;
    private float attackRange;
    private float timeTillTalking;
    private bool grounded;
    //AI_behaviors
    // 1 = walking
    // 2 = attacking
    // 3 = yelling vulgar things
    // 4 = dying

    public float activationRange;
    public int AI_Behavior = 1;
    // Start is called before the first frame update
    void Start()
    {
        transform.localEulerAngles = new Vector3(0, -90, 0);
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        //walkSpeed = 15;
        AI_Behavior = 0;
        attackRange = 1.7f;
        walkSpeed = 2;
        activationRange = 15f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distanceToPlayer = Mathf.Abs(Vector3.Distance(transform.position, player.transform.position));

        //re orient the enemy if the player crosses over it(or at least gets reatll close.
        if(Mathf.Abs(player.transform.position.x - transform.position.x)< 0.3f)
        {
            OrientRoamer();
        }

        if (activated == false && distanceToPlayer < activationRange)
        {
            activated = true;
            OrientRoamer();
            AI_Behavior = 1;
            timeTillTalking = Random.Range(2.0f, 5.0f);
        }
        if (AI_Behavior == 1)
        {
            if (grounded)// just wanna make sure e's on the ground before he starts pushing forward.
                //otherwise the rigidbody makes him kinda float.
            {
                //count down the time till he says somethign insulting
                timeTillTalking -= Time.deltaTime;
                //make the roamer walk forward until then
                if (timeTillTalking > 0)
                {
                    rb.velocity = transform.forward * walkSpeed;
                }
                else
                {
                    //shout something and then somehow make it go back to walk(reset the timer) after it's finished
                }
            }
            //count down the time till he says somethign insulting
            timeTillTalking -= Time.deltaTime;
            //make the roamer walk forward until then
            if(timeTillTalking > 0)
            {
                if (grounded)
                {
                    rb.velocity = transform.forward * walkSpeed;
                }
                
            }
            else
            {
                //shout something and then somehow make it go back to walk(reset the timer) after it's finished
            }

        }
        //if the player gets to close, trigger the attack
        if (AI_Behavior == 1 && distanceToPlayer < 2f)
        {

            AI_Behavior = 2;
        }

        //attack and then go back to phase 3 for a while
        if(AI_Behavior == 2)
        {
            //attack animation. then a few seconds pause
            //attack
            Invoke("GoTOAI1", 2.0f);
        }


    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Energy Ball"))
        {
            Die();
        }
        if (other.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    void OrientRoamer()
    {
        //orient the roamer to face the player
        if (player.transform.position.x < transform.position.x)
        {
            transform.localEulerAngles = new Vector3(0, -90, 0);
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 90, 0);
        }
    }

    void GoTOAI1()
    {
        AI_Behavior = 1;
    }

    void Die()
    {
        //plan animation, Invoke the explosion afterward
        DeathExplosion();

        //then destroy the object
        Destroy(this.gameObject);
    }

    void DeathExplosion()
    {
        Instantiate(deathExpl, transform.position, Quaternion.identity);
    }

    public void GetJumpedOn()
    {
        //Trigger hurt animation

        //make the player bounce
        player.GetComponent<playerScript>().HeadBounce(400.0f);

        //destroy
        Die();
    }
}
