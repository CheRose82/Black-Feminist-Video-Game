using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crawlerScript : MonoBehaviour
{
    public GameObject player;
    public GameObject deathExpl;
    public GameObject weakSpot;
    Rigidbody rb;
    private float walkSpeed;
    public float distanceToPlayerX;
    public bool facingRight = false;
    public bool activated = false;
    public bool walking = true;
    private float lurchPoint;
    public int health;
    private bool vulnerable;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        walkSpeed = 0.07f;
        lurchPoint = 3.0f;
        rb = GetComponent<Rigidbody>();
        health = 3;
        vulnerable = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //constantly measure the distance between the itself and the player
        distanceToPlayerX = Mathf.Abs(transform.position.x - player.transform.position.x);

        //if the player gets close enough to where it's visible on the game screen, activate
        if(distanceToPlayerX < 24.6f)
        {
            activated = true;
        }

        ////force test
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    rb.AddForce(500, 10, 0);
        //}
        //basic walking
        if (activated)
        {
            if (walking)
            {
                transform.Translate(0, 0, walkSpeed);
                //if (!facingRight)
                //{
                //    transform.Translate(0, 0, walkSpeed);
                //}
                //else
                //{
                //    transform.Translate(0, 0, -walkSpeed);
                //}
            }

            //Lurch if he gets close enough to the player
            if(distanceToPlayerX < lurchPoint && walking)
            {
                if (!facingRight  && player.transform.position.x < transform.position.x)
                {
                    Lurch(-1);
                }
                if (facingRight && player.transform.position.x > transform.position.x)
                {
                    Lurch(1);
                }
            }

            
        }

        
}
    public void OnTriggerEnter(Collider other)
    {
        //if it hits an AI boundary or a regular boundary, turnaround
        if (other.CompareTag("AIBoundary") && walking)
        {
            if (facingRight)
            {
                facingRight = false;
                //transform.localScale = new Vector3(1, 1, 1);
                transform.Rotate(0, 180, 0);
            }
            else
            {
                facingRight = true;
                //transform.localScale = new Vector3(-1, 1, 1);
                transform.Rotate(0, 180, 0);
            }
        }

        //if it hits the player, the player flies bavkward
        if (other.CompareTag("Player"))
        {
            Debug.Log("The crawler felt the the player");
            rb.velocity = Vector3.zero;
            //now the crawler will both repel the player and recoil a tiny bit
            if(facingRight == false)
            {
                rb.AddForce(100, 200, 0);
                CancelInvoke("FlipHorizontal");
            }
            else
            {
                rb.AddForce(-100, 200, 0);
                CancelInvoke("FlipHorizontal");
                
            }
        }

        //the the roamer gets touched by an energy ball
        if(other.CompareTag("Energy Ball"))
        {
            if(vulnerable == true)
            {
                Debug.Log("the roamer felt the energy ball");

                health--;
                if (health <= 0)
                {
                    Die();
                }
                rb.velocity = Vector3.zero;
                walking = false;
                Invoke("Activated", 2.0f);
                GetHit();
                
            }
            
            
        }

        
    }

    public void Lurch(int dir)
    {
        walking = false;
        rb.AddForce((500 * dir), 150,0);
        Invoke("FlipHorizontal",0.5f);
        Invoke("LurchReset", 1.0f);
    }
    public void ToggleWalking()
    {
        if (walking)
        {
            walking = false;
        }
        else
        {
            walking = true;
        }
    }
    public void FlipHorizontal()
    {
        transform.Rotate(0, 180, 0);
        //if (facingRight)
        //{
        //    transform.localScale = new Vector3 (1, 1, 1);
        //}
        //else
        //{
        //    transform.localScale = new Vector3(-1, 1, 1);
        //}
    }
    public void LurchReset()
    {
        walking = true;
        if (facingRight)
        {
            facingRight = false;
            transform.Rotate(0, 180, 0);

        }
        else
        {
            facingRight = true;
        }
    }

    void Die()
    {
        //plan animation, Invoke the explosion afterward
        DeathExplosion();

        //then destroy the object
        Destroy(this.gameObject);
    }

    public void GetJumpedOn()
    {
        //Trigger hurt animation

        //make the player bounce
        player.GetComponent<playerScript>().HeadBounce(400.0f);

        //destroy
        Die();
    }
    void Activated()
    {
        walking = true;
    }
    void DeathExplosion()
    {
        Instantiate(deathExpl, transform.position, Quaternion.identity);
    }
    void GetHit()
    {
        vulnerable = false;
        Invoke("MakeVulnerable", 0.5f);

    }
    void MakeVulnerable()
    {
        vulnerable = true;
    }

    void Orient()
    {
        if(player.transform.position.x < transform.position.x)
        {
            facingRight = false;
            //FlipHorizontal();
        } else
        {
            facingRight = true;
        }
    }
    


}
