using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{

    public float runSpeed;
    public GameObject jonasAnim;
    public GameObject sabine;
    //public GameObject sprite;
    //public GameObject nicole;
    public Animator anim;
    public GameObject groundProj;
    public GameObject airProj;
    public GameObject leftNozzle;
    public GameObject rightNozzle;
    public GameObject leftNozAir;
    public GameObject rightNozAir;
    public GameObject unicorn;
    public GameObject glitterDB;
    public GameObject heyWatchDB;
    public GameObject crackMirror;
    public GameObject breakFreeMirror;
    public GameObject DBp50;
    public GameObject DBp38Oww;
    public GameObject DBp39SeeAllShe;
    public GameObject axe;
    public bool Grounded;
    public bool walking;
    public GameObject dbFindWhat;
    //public Animator anim;
    Rigidbody rb;
    public bool facingRight = true;
    public bool readyToShoot;
    public bool hasControl = true;
    public bool RideUnicornAttempt;
    public bool canPetUnicorn;
    private Vector3 returnPos;

    //sfx
    public AudioClip jumpClip;
    public AudioClip energyBallClip;
    public AudioClip goddessClip;
    public AudioClip SkeletonClip;
    public AudioClip telescopeOn;
    public AudioClip telescopeOff;
    public AudioClip hairClip;
    public AudioClip groundClip;
    public AudioClip receivedItemClip;
    public AudioClip horseKickedClip;
    public AudioClip mirrorBreakClip;

    public AudioSource playerSource;

    public GameObject glassRain;
    public GameObject womensVoicePart;
    public GameObject DBpWeDidIt;
    public GameObject whiteJonas;
    
    // Start is called before the first frame update
    void Start()
    {
        playerSource = GetComponent<AudioSource>();
        runSpeed = 0.05f;
        rb = GetComponent<Rigidbody>();
        //nicole = GameObject.Find("Nicole");
        facingRight = true;
        readyToShoot = true;
        hasControl = true;
        breakFreeMirror = GameObject.Find("Mirror Break Free");
        axe = GameObject.Find("axe");
        sabine = GameObject.Find("Sabine");
        whiteJonas = GameObject.Find("jonas white");
        whiteJonas.GetComponent<SpriteRenderer>().enabled = false;
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

        //animation stuff
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetBool("isRunning", true);
            jonasAnim.transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetBool("isRunning", true);
            jonasAnim.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("isRunning", false);
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
                    playerSource.PlayOneShot(jumpClip, 7);
                    anim.SetTrigger("jumpTrigger");
                    
                }
            }
            
        }
        //throw ground/air energy ball energy ball
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootEnergyBall();
            playerSource.PlayOneShot(energyBallClip, 7);
            

        }

        //goddess pose
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isOnGround", true);
            anim.SetTrigger("goddessTrigger");
            playerSource.PlayOneShot(goddessClip, 7);
        }

        //dacne
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isOnGround", true);
            anim.SetTrigger("danceTrigger");
        }

        //umbrella pose
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isOnGround", true);
            anim.SetTrigger("umbrellaTrigger");
            GlassOnJonas();
        }

        //raise hand, end level, also pet the horse
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isOnGround", true);
            anim.SetTrigger("handTrigger");
            if(canPetUnicorn == true)
            {
                Invoke(nameof(UnicornRunAway), 3.5f);
                Instantiate(DBp39SeeAllShe, transform.position, Quaternion.identity);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Bones();
            sabine.GetComponent<sabineControlScript>().Skel();
            playerSource.PlayOneShot(SkeletonClip, 7);
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            anim.SetBool("usingTelescope", false);
            playerSource.PlayOneShot(telescopeOn, 7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            anim.SetBool("usingTelescope", true);
            playerSource.PlayOneShot(telescopeOff, 7);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Instantiate(dbFindWhat, transform.position, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            GiveHair();
            playerSource.PlayOneShot(hairClip, 5);
        }




        ////if statements for the horizontal flip
        //if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    //sprite.transform.localScale = new Vector3(1, 1, 1);
        //}

        //if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    //sprite.transform.localScale = new Vector3(-1, 1, 1);
        //}
    }
    public void OnTriggerEnter(Collider other)
    {
        ///TERRAIN (mostly ground)
        if (other.CompareTag("Ground"))
        {
            anim.SetBool("isOnGround", true);
            Grounded = true;
            rb.velocity = Vector3.zero;
            playerSource.PlayOneShot(groundClip, 4);
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
            anim.SetBool("isChopping", true);
            Invoke(nameof(StopChopping), 7);
            Invoke(nameof(StartVoiceParticles), 2);
            //Debug.Log("We touched the axe");
            //animate holding up the Axe
            playerSource.PlayOneShot(receivedItemClip, 7);
        }

        //unicorn
        if (other.CompareTag("BlackUnicorn"))
        {
            if(canPetUnicorn == false)
            {
                Debug.Log("he should have touched the unicorn");
                if (RideUnicornAttempt == false)
                {
                    //trigger ride horse animation
                    // and then trigger hiim getting kicked off
                    unicorn.GetComponent<BlackUnicornScript>().Kick();
                    KickedOffUnicorn();
                    RideUnicornAttempt = true;
                    Instantiate(DBp38Oww, transform.position, Quaternion.identity);
                    canPetUnicorn = true;
                }
                else //after above when he's abou tto get glitter bombed
                {
                    //invoke the glitter bomb

                    //unicorn.GetComponent<BlackUnicornScript>().AIBehavior = 4;
                    Invoke("GlitterBomb", 1.0f);
                    rb.AddForce(-700, 150, 0);
                    Debug.Log("The glitter bomb happened on the player side");
                }
            }
            else // you have already beenkicked and can now pet the unicorn
            {
                Invoke(nameof(UnicornRunAway), 2);
            }
            
        }

        //white Jonas come
        if (other.CompareTag("Spotlight"))
        {
            jonasAnim.GetComponent<SpriteRenderer>().enabled = false;
            whiteJonas.GetComponent<SpriteRenderer>().enabled = true;
        }

       
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            anim.SetBool("isOnGround", false);
            Grounded = false;
        }

        //white Jonas come
        if (other.CompareTag("Spotlight"))
        {
            jonasAnim.GetComponent<SpriteRenderer>().enabled = true;
            whiteJonas.GetComponent<SpriteRenderer>().enabled = false;
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
                    playerSource.PlayOneShot(energyBallClip, 7);
                }
                else
                {
                    Instantiate(groundProj, leftNozzle.transform.position, leftNozzle.transform.rotation);
                    playerSource.PlayOneShot(energyBallClip, 7);
                }

            }
            else //this basicalyl means he's throwing the ari fireball because grounded is not true
            {
                if (facingRight == true)
                {
                    Instantiate(airProj, rightNozAir.transform.position, rightNozAir.transform.rotation);
                    playerSource.PlayOneShot(energyBallClip, 7);
                }
                else
                {
                    Instantiate(airProj, leftNozAir.transform.position, leftNozAir.transform.rotation);
                    playerSource.PlayOneShot(energyBallClip, 7);
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
        anim.SetTrigger("becomeSkeleton");
    }

    public void KickedOffUnicorn()
    {
        rb.AddForce(-700, 150, 0);
        KickedAnim();
        playerSource.PlayOneShot(horseKickedClip, 7);
    }

    public void GlitterBomb()
    {
        unicorn.GetComponent<BlackUnicornScript>().GBomb();
        rb.AddForce(-200, 100, 0);
        Invoke("HeyWatchItDB", 0.5f);
        playerSource.PlayOneShot(horseKickedClip, 7);
    }

    public void HeyWatchItDB()
    {
        heyWatchDB.active = true;
        Debug.Log("Spawning the dialogue box worked");
    }

    public void Dance()
    {
        //fire the animation for dancing
        Debug.Log("Jonas is dancing");
        Invoke(nameof(StopDancing), 4f);

        //next you have to create a reference to the Nicole Mirros animation and start her dancing
    }

    public void StopDancing()
    {
        //avatar nicole stops dancing 
        //and then one of the mirrors shatters
        //Jonas Stops dancing
        Invoke(nameof(JonasStopDancing), 3);
        Debug.Log("Everyone stops dancing. The other mirror is about to crack");
    }

    public void JonasStopDancing()
    {
        //jonas stops dancing
        Invoke(nameof(MirrorBreaks), 1);
    }

    public void MirrorBreaks()
    {
        crackMirror.GetComponent<MirrorBreaks>().CrackMirror();
        playerSource.PlayOneShot(mirrorBreakClip, 7);
    }

    public void BreakFreeMirror()
    {
        returnPos = transform.position;
        transform.position = breakFreeMirror.transform.position + new Vector3(1, 0, 0);
        rb.useGravity = false;
        //start the swing hammer animation

        Invoke(nameof(BreakFreeMirror2), 3.0f);
        
    }

    public void BreakFreeMirror2()
    {
        breakFreeMirror.GetComponent<MirrorBreakSabFree>().CrackMirror();
        transform.position = returnPos;
        rb.useGravity = true;
        //add the animation for the umbrella here

        //now instantiate an object to start the next script
        Instantiate(DBp50, transform.position + new Vector3(0, -100, 0), Quaternion.identity);
        Debug.Log("He instantiated the dialgue box");

    }

    public void GlassOnJonas()
    {
        Instantiate(glassRain, transform.position + new Vector3(0, 20, 0), Quaternion.identity);
    }

    public void KickedAnim()
    {
        anim.SetTrigger("abductedTrigger");
    }

    public void UnicornRunAway()
    {
        unicorn.GetComponent<BlackUnicornScript>().AIBehavior = 3;
    }

    public void StopChopping()
    {
        anim.SetBool("isChopping", false);
    }

    public void StartVoiceParticles()
    {
        Instantiate(womensVoicePart, transform.position + new Vector3(25, 5, 0), Quaternion.identity);
        Debug.Log("particles should be flowing");
    }

    public void GiveHair()
    {
        unicorn.GetComponent<BoxCollider>().enabled = false;
        anim.SetTrigger("cutHair");
        Invoke(nameof(UnicornRunAway), 5);
        Invoke(nameof(WeDidIt), 10);
    }

    public void WeDidIt()
    {
        Instantiate(DBpWeDidIt, transform.position, Quaternion.identity);
    }
}
