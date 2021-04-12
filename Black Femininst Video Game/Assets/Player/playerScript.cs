using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{

    public float runSpeed;
    //public GameObject sprite;
    //public GameObject nicole;
    public GameObject groundProj;
    public GameObject airProj;
    public GameObject leftNozzle;
    public GameObject rightNozzle;
    public GameObject leftNozAir;
    public GameObject rightNozAir;
    public GameObject unicorn;
    public GameObject glitterDB;
    public GameObject heyWatchDB;
    public bool Grounded;
    public bool walking;
    //public Animator anim;
    Rigidbody rb;
    public bool facingRight = true;
    public bool readyToShoot;
    public bool hasControl = true;
    public bool RideUnicornAttempt;
    
    // Start is called before the first frame update
    void Start()
    {
        runSpeed = 0.05f;
        rb = GetComponent<Rigidbody>();
        //nicole = GameObject.Find("Nicole");
        facingRight = true;readyToShoot = true;
        hasControl = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (hasControl)
            {
                transform.Translate(-runSpeed, 0, 0);
            }
            
            if(facingRight == true)
            {
                facingRight = false;
               
            }

        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (hasControl)
            {
                transform.Translate(runSpeed, 0, 0);
            }
            
            if (facingRight == false)
            {
                facingRight = true;
                
            }
        }

        //trigger for the run anim
        if (Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.RightArrow))
        {
            //anim.SetBool("Running", true);
            walking = true;


        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            //anim.SetBool("Running", false);
            walking = false;

        }

        if (Grounded)
        {
            if (hasControl)
            {
                //jump
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    //anim.SetTrigger("JumpingTrigger");
                    rb.velocity = Vector3.up * 7.5f;
                }
            }
            
        }
        //throw ground/air energy ball energy ball
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootEnergyBall();
        }


        //if statements for the horizontal flip
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //sprite.transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //sprite.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        ///TERRAIN (mostly ground)
        if (other.CompareTag("Ground"))
        {
            //anim.SetBool("onGround", true);
            Grounded = true;
            rb.velocity = Vector3.zero;
        }

        if (other.CompareTag("NicoleAct"))
        {
            //nicole.GetComponent<NicoleNPCScript>().activated = true;
        }

        //ENEMIES
       
        if(other.CompareTag("Falling Rock"))
        {
            Debug.Log("The player knows that they are dead.");
            //player loses health or whatever
        }

        if (other.CompareTag("Crawler"))
        {
            Debug.Log("touched the crawler");
            if(facingRight == true)
            {
                rb.AddForce(10, 5, 0);
            }
            else
            {
                rb.AddForce(-10, 5, 0);
            }
        }


        //ITEMS
        if (other.CompareTag("Axe"))
        {
            Destroy(other.gameObject);
            Debug.Log("We touched the axe");
            //animate holding up the Axe
        }

        //unicorn
        if (other.CompareTag("BlackUnicorn"))
        {
            Debug.Log("he should have touched the unicorn");
            if(RideUnicornAttempt == false)
            {
                //trigger ride horse animation
                // and then trigger hiim getting kicked off
                KickedOffUnicorn();
                RideUnicornAttempt = true;
            }
            else //after above when he's abou tto get glitter bombed
            {
                //invoke the glitter bomb
                Invoke("GlitterBomb", 4.0f);
                Debug.Log("The glitter bomb happened on the player side");
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            //anim.SetBool("onGround", false);
            Grounded = false;
        }
    }

    public void ShootEnergyBall()
    {
        if(readyToShoot == true)
        {

            if (Grounded == true)
            {
                if (facingRight == true)
                {
                    Instantiate(groundProj, rightNozzle.transform.position, rightNozzle.transform.rotation);
                }
                else
                {
                    Instantiate(groundProj, leftNozzle.transform.position, leftNozzle.transform.rotation);
                }

            }
            else //this basicalyl means he's throwing the ari fireball because grounded is not true
            {
                if (facingRight == true)
                {
                    Instantiate(airProj, rightNozAir.transform.position, rightNozAir.transform.rotation);
                }
                else
                {
                    Instantiate(airProj, leftNozAir.transform.position, leftNozAir.transform.rotation);
                }
            }

            readyToShoot = false;
            Debug.Log("ready to shoot should be false");
            Invoke("ResetShoot", 0.5f);
            
        }
        
        
    }

    public void HeadBounce(float height)
    {
        //first cancel out all velocity
        rb.velocity = Vector3.zero;

        //then bounce him straight up the amoung passed through in the height variable
        rb.AddForce(0, height, 0);
        //Debug.Log("The player should have bounced by " + height);
    }

    void ResetShoot()
    {
        readyToShoot = true;
    }

    public void LoseControl(float time)
    {
        hasControl = false;
        Invoke("RegainControl", time);
    }
    void RegainControl()
    {
        hasControl = true;
    }

    public void Bones()
    {
        //play animation for turning to bones
    }

    public void KickedOffUnicorn()
    {
        rb.AddForce(-700, 150, 0);
    }

    public void GlitterBomb()
    {
        unicorn.GetComponent<BlackUnicornScript>().GBomb();
        rb.AddForce(-200, 100, 0);
        Invoke("HeyWatchItDB", 3.0f);
    }

    public void HeyWatchItDB()
    {
        heyWatchDB.active = true;
        Debug.Log("Spawning the dialogue box worked");
    }
}
