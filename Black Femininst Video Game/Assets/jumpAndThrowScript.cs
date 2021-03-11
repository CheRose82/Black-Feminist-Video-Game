using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpAndThrowScript : MonoBehaviour
{
    Rigidbody rb;
    public GameObject player;
    public GameObject front;
    public GameObject projectile;
    public GameObject deathExpl;
    public float distanceToPlayer;
    public float walkSpeed;
    public float jumpStrength;
    public bool activated;
    public Vector3 nextPos;
    private float groundHeight;
    private float jumpHeight;
    private int health;
    public float activationRange;
    public int AI_Behavior = 1;
    //AI_Behaviors
    //1 - walking forward
    //2 - running towards jump point
    //3 jump
    //4 jumping
    //5 falling

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        //walkSpeed = 15;
        AI_Behavior = 0;
        jumpHeight = 3.15f;
        health = 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distanceToPlayer = Mathf.Abs(Vector3.Distance(transform.position, player.transform.position));
        if (activated == false && distanceToPlayer < activationRange) 
        {
            activated = true;
            AI_Behavior = 1;
        }
        if (AI_Behavior ==1)
        {
            rb.velocity = transform.forward * walkSpeed;
        }
        if(AI_Behavior == 1 && distanceToPlayer < 6f)
        {
            
            FindJumpPoint();
            FaceJumpPoint();
            AI_Behavior = 2;
        }

        //if AI_Behavior is 2, walk to the jump point
        if(AI_Behavior == 2)
        {
            if(Mathf.Abs(transform.position.x - nextPos.x)> 0.2f)
            {
                rb.velocity = transform.forward * walkSpeed;
            }
            else
            {
                FacePlayer();
                AI_Behavior = 3;
            }
        }

        //jump and then stop jumping
        if(AI_Behavior == 3)
        {
            Jump();
            AI_Behavior = 4;
        }

        //if the height goes above the height plus 6.7
        if(AI_Behavior == 4)
        {
            if(transform.position.y > groundHeight + jumpHeight)
            {
                AirFreeze();
            }
        }

        //when the enemy lands, we reset to the point where he finds a new point, runs to it and then jumps again
        
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("AIBoundary"))
        {
            transform.Rotate(0, 180, 0);
            Debug.Log("touched the boundary and didn't know it ");
        }

        if (other.CompareTag("Ground"))
        {
            if(AI_Behavior == 5)
            {
                FindJumpPoint();
                FaceJumpPoint();
                AI_Behavior = 2;
            }
        }

        //if he gets hit
        if(other.CompareTag("Energy Ball"))
        {
            if(health <= 0)
            {
                Die();
            }
            health--;
        }
    }

    private void FindJumpPoint()
    {
        float nextX = Random.Range(transform.position.x - 2f, transform.position.x + 2);
        nextPos = new Vector3(nextX, transform.position.y, transform.position.z);
    }
    private void FaceJumpPoint()
    {
       if(transform.position.x < nextPos.x)
        {
            transform.Rotate(0, 180, 0);
            
        }
    }
    private void FacePlayer()
    {
        if (transform.position.x > player.transform.position.x && front.transform.position.x > transform.position.x)
        {
            //Debug.Log("it's facing to the right");
            if(transform.position.x > player.transform.position.x)
            {
                transform.Rotate(0, 180, 0);
                //Debug.Log("it should be turning around");
            }
        }
    }

    //grab the y position and then jump
    private void Jump()
    {
        groundHeight = transform.position.y;
        rb.velocity = Vector3.zero;
        rb.AddForce(0, 400, 0);
    }

    private void AirFreeze()
    {
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        //Debug.Log("It should be freezing in place");
        Invoke("ThrowObject", 0.5f);
        AI_Behavior = 5;
    }

    private void ThrowObject()
    {
        Instantiate(projectile, transform.position, transform.rotation);
        Fall();
        //AI_Behavior = 5;
    }

    private void Fall()
    {
        rb.useGravity = true;
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
