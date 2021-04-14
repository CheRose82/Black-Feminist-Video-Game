using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChauvanimsusScript : MonoBehaviour
{
    public GameObject body;//the big cube that will serve has primary hit box
    public GameObject player;
    public GameObject rightBoundary;//limit on how far right he can move. Can or cannot be visible
    public GameObject walkBoundary;//empty object that dictates how far left he will walk
    public GameObject meleePos;
    public GameObject meleeHitBox;
    public GameObject barrel;
    public GameObject canon;
    public GameObject leftFlightSpawn;
    public GameObject rightFlightSpawn;
    public GameObject topFlightRespawn;
    public GameObject impactParticles;
    public GameObject enemyAdds;
    //Rigidbody rb;
    public int AI_Behavior;
    public int health;
    public float walkTimer;//how long he walks during AI_Behavior1
    private float walkTimerReset;
    public bool walking;
    public bool movingLeft;
    private bool AI_1_Calc_Made;//have the calculations been made at the start of AI1
    public float walkSpeed;
    private float walkSpeedAdj;//I'll multiply the walkSpeed by this numberto make it go faster as he takes more damage
    private bool repositioning;
    private float ChauvHeight;
    private float repositioningTimer;
    private float repositioningTimerReset;
    private float chargingTimer;
    private float chargingTimerReset;
    public float leftLowChargingTimer;
    private float leftLowChargingTimerReset;
    public float rightLowchargingTimer;
    private float rightLowchargingTimerReset;
    private bool LowChargeAdj;
    private bool barrelRolled;
    private bool canonShot;
    private bool canonShooting;
    private float canonTimer;
    private int flyingUp;
    // I changed this from a bool
    //1 is flying up
    //2 is flyign across
    //3 is falling down
    private float flyingUpTimer;
   
    private float flyDirection;
    private bool flyingFromLeft;
    private float diveTimer;
    private bool fallingDown;
    private float fallSpeed;
    private bool impacted;
    private float enemyDropTimer;
    private bool waitingToDuck;
    private float duckTimer;

    //grab Jonas Core position
    public Vector3 jonasCentralPos;
    public Vector3 chauvCentralPos;

    //Actions:
    // 1 Walk back an forth
    // 2 deciding
    // 3 Melee attack
    // 4 High charging attack
    // 5 Low charging attack
    // 6 Barrel Bomb
    // 7 Canon blast
    // 8 fly up, then across while dropping enemies

    // Start is called before the first frame update
    void Start()
    {
        AI_Behavior = 1;
        walkTimer = 5.0f;
        walkTimerReset = 5f;
        //walkSpeed = 0.1f;
        //movingLeft = true;
        walkSpeedAdj = 1.0f;
        health = 100;
        ChauvHeight = transform.position.y;
        repositioningTimer = 3.0f;
        repositioningTimerReset = 3.0f;
        chargingTimer = 4.0f;
        chargingTimerReset = 4.0f;
        leftLowChargingTimer = 3.0f;
        leftLowChargingTimerReset = 3.0f;
        rightLowchargingTimer = 3.0f;
        rightLowchargingTimerReset = 3.0f;
        flyingUp = 1;
        flyingUpTimer = 5.0f;
        diveTimer = 5.0f;
        fallingDown = false;
        fallSpeed = .01f;
        enemyDropTimer = 0.5f;
        waitingToDuck = true;
        duckTimer = 1.0f;
        //rb = GetComponent<Rigidbody>();

}

    // Update is called once per frame
    void Update()
    {
        Debug.Log(" the random number is " + Random.Range(1, 8));
        if(AI_Behavior == 0)
        {
            //Do nothing. Use this space to call courotines and cutscenes.
        }

        if(AI_Behavior == 1)
        {
            //first we need to decide whether or not he's about to move left or right 
            if(AI_1_Calc_Made == false)
            {
                if(transform.position.x > ((walkBoundary.transform.position.x + rightBoundary.transform.position.x) / 2))
                {
                    movingLeft = true;
                }
                else
                {
                    movingLeft = false;
                }
                AI_1_Calc_Made = true;
                walking = true;

            }

            if(AI_1_Calc_Made == true)
            {
                //start counting down the timer
                walkTimer -= Time.deltaTime;
                
                if(walkTimer > 0)
                {
                    //Debug.Log("It's this far from the right border " + Vector3.Distance(this.gameObject.transform.position, rightBoundary.transform.position));
                    if (walking == true)
                    {
                        if (movingLeft == true)
                        {
                            transform.Translate(-walkSpeed * walkSpeedAdj, 0, 0);
                        }
                        else
                        {
                            transform.Translate(walkSpeed * walkSpeedAdj, 0, 0);
                        }
                    }

                    // if the boss gets to close to the walk border or the right border
                    if (Vector3.Distance(this.gameObject.transform.position, rightBoundary.transform.position) < 8.5f || Vector3.Distance(this.gameObject.transform.position, walkBoundary.transform.position) < 8)
                    {
                        walking = false;
                        //Debug.Log("fuck it");

                        ChangeDir();
                        Invoke("WalkingTrue", 1.5f);
                    }
                }
                else
                {
                    AI_Behavior = 2;//deciding what to do next
                    //Debug.Log("walk timer became less than zero");
                    walking = false;
                    walkTimer = walkTimerReset;
                    AI_1_Calc_Made = false;
                }
            }
        }

        //deciding
        if(AI_Behavior == 2)
        {
            DecideNextAI();
            //Debug.Log("We decided");
        }

        // 1-2 punch melee attack
        if(AI_Behavior == 3)
        {
            Invoke("PunchOne", 1.0f);
            Invoke("PunchTwo", 2.5f);
            AI_Behavior = 0;
        }

        //High charging attack
        if(AI_Behavior == 4)
        {
            if(repositioning == true)
            {
                repositioningTimer -= Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, rightBoundary.transform.position + new Vector3(-4.5f, 0, 0), walkSpeed * 3);

                //when the timer repositioning timer runs out, make repositioing false and then start the charge
                if(repositioningTimer < 0)
                {
                    
                    repositioning = false;
                    repositioningTimer = repositioningTimerReset;
                }
            }

            //the charge
            if(repositioning == false)
            {
                if(chargingTimer > 0)
                {
                    chargingTimer -= Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, walkBoundary.transform.position + new Vector3(2, 0, 0), walkSpeed * 2);
                    
                }
                else //when it stops return to the origin point on the right side fo the screen.
                {
                    transform.position = Vector3.MoveTowards(transform.position, rightBoundary.transform.position + new Vector3(-4.5f, 0, 0), walkSpeed * 1.5f);
                    Debug.Log("chargingTimer is " + chargingTimer);
                    Debug.Log("distance between chauv and the rightborder is " + Vector3.Distance(transform.position, rightBoundary.transform.position));

                    if(Vector3.Distance(transform.position, rightBoundary.transform.position) < 8.5f)//the last number will change if you don't keep the exact same positioning 
                    {
                        //AI_Behavior = 2;

                        GoToAI1();
                        Debug.Log("It should be working");
                        //Debug.Log("repositioning is " + repositioning + ", charginTimer is " + chargingTimer + ", and the distance between chauv and the rightborder is " + Vector3.Distance(transform.position, rightBoundary.transform.position));
                        chargingTimer = chargingTimerReset;
                    }
                }
           
            }

            
        }

        if(AI_Behavior == 5)//repoisition down a bit, zoom left off the screen then back right
        {
            if(LowChargeAdj == false)
            {
                duckTimer -= Time.deltaTime;
                if (duckTimer < 0)
                {
                    Debug.Log("Ducked");
                    transform.position = new Vector3(transform.position.x, transform.position.y - 6f, transform.position.z);
                    LowChargeAdj = true;
                    //waitingToDuck = false;
                    duckTimer = 1.0f;
                }

                //Debug.Log("Ducked");
                //transform.position = new Vector3(transform.position.x, transform.position.y - 6f, transform.position.z);
                //LowChargeAdj = true;
            }
            else
            {
                if(leftLowChargingTimer > 0)
                {
                    leftLowChargingTimer -= Time.deltaTime;
                    transform.Translate(-.11f, 0, 0);
                    Debug.Log("charging left");
                }
                if(leftLowChargingTimer < 0)
                {
                    rightLowchargingTimer -= Time.deltaTime;
                    transform.Translate(.11f, 0, 0);
                    Debug.Log("charging right");
                }
                if(rightLowchargingTimer < 0)
                {
                    leftLowChargingTimer = 0;
                    //once it goes back to the right: stop it, reset everything, and go back to AI_behavior 2
                    //but first I'm going to use theold duck variables to make him wait a second.

                    duckTimer -= Time.deltaTime;
                    if (duckTimer < 0)
                    {
                        GoToAI1();
                        transform.position = new Vector3(transform.position.x, 7.21f, transform.position.z);
                        leftLowChargingTimer = leftLowChargingTimerReset;
                        rightLowchargingTimer = rightLowchargingTimerReset;
                        LowChargeAdj = false;
                        waitingToDuck = true;
                        duckTimer = 1.0f;
                    }

                }
                
            }
        }

        if(AI_Behavior == 6)//roll the exploding barrel
        {
            if (barrelRolled == false)
            {
                Invoke("BarrelRollPause", 1.3f);//the number is how long it takes to get the barrel roll animation to complete
                barrelRolled = true;
            }
        }

        if(AI_Behavior == 7)//shoot the canon
        {
            if(canonShot == false)
            {
                Invoke("CanonShotPause", 1.3f);//how long before canon animation completes
                Invoke("GoToAI1", 5.0f);
                canonShot = true;
                
            }
            else
            {
                canonTimer -= Time.deltaTime;
                if (canonTimer < 0)
                {
                    Instantiate(canon, transform.position, Quaternion.identity);
                    canonTimer = 0.03f;
                }
            }
        }

        if(AI_Behavior == 8)//
        {
            if(flyingUp == 1)
            {
                flyingUpTimer -= Time.deltaTime;
                transform.Translate(0, 0.07f, 0);
                if(flyingUpTimer < 0)
                {
                    flyingUp = 2;
                    flyingUpTimer = 5.0f;
                    flyDirection = Random.Range(0.0f, 1.0f);

                    if(flyDirection < 0.5f)
                    {
                        transform.position = leftFlightSpawn.transform.position;
                        flyingFromLeft = true;
                        flyingUp = 2;
                    }
                    else
                    {
                        transform.position = rightFlightSpawn.transform.position;
                        flyingFromLeft = false;
                        flyingUp = 2;
                        
                    }

                }
            }
            if(flyingUp == 2) // dive down from either direction
            {
                diveTimer -= Time.deltaTime;
                if(diveTimer > 0)
                { 
                    if(walkBoundary.transform.position.x < transform.position.x && transform.position.x < rightBoundary.transform.position.x)
                    {
                        enemyDropTimer -= Time.deltaTime;
                        if (enemyDropTimer < 0)
                        {
                            //instantiate the enemy
                            Instantiate(enemyAdds, transform.position, Quaternion.identity);
                            enemyDropTimer = 0.5f;
                        }
                    }
                
                    if (flyingFromLeft)
                    {
                        transform.Translate(0.13f, -0.008f, 0);
                    }
                    else
                    {
                        transform.Translate(-0.13f, -0.008f, 0);
                    }
                } else
                {
                    transform.position = topFlightRespawn.transform.position;
                    flyingUp = 3;
                    diveTimer = 5.0f;
                    
                }
                
                
            }
            if(flyingUp == 3)//fall down and increase fall speed
            {
                if(transform.position.y > 7.21f)
                {
                    transform.Translate(0, -fallSpeed, 0);//fall down
                    fallSpeed *= 1.035f;//increase the fall speed
                }
               
                //if it touches the ground stop and make dust come out the ground
                else
                {
                    transform.position = new Vector3(transform.position.x, 7.21f, transform.position.z);
                    //eplosion when you hit the ground
                    if(impacted == false)
                    {
                        Instantiate(impactParticles, transform.position + new Vector3(0, -5, 0), Quaternion.identity);
                        impacted = true;
                    }
                    
                    Invoke("GoToAI1", 1.0f);
                    fallSpeed = .01f;
                }
            }
        }

        if(AI_Behavior == 9)//mirror jonas
        {
            float yPos = chauvCentralPos.y + (player.transform.position.y - jonasCentralPos.y);
            float xPos = chauvCentralPos.x - (player.transform.position.x - jonasCentralPos.x);
            transform.position = new Vector3(xPos, yPos, 0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))//should be reg 9
        {
            //first grab Jonas Position. Make sure he is in the center of the left first
            jonasCentralPos = player.transform.position;
            chauvCentralPos = new Vector3(163f, 7.5f, 0f);
            transform.position = new Vector3(163f, 7.5f, 0f);

            AI_Behavior = 9;
            Debug.Log("chauv should be at ai9");
        }
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Ground"))
    //    {
    //        transform.position = new Vector3(transform.position.x, -.12f, transform.position.y);
    //        Debug.Log("It touched the ground");
    //    }
    //}

    public void WalkingTrue()
    {
        walking = true;
    }

    public void ChangeDir()
    {
        if (movingLeft)
        {
            movingLeft = false;
        }
        else
        {
            movingLeft = true;
        }
    }

    public void DecideNextAI()
    {
        //AI_Behavior = 4;

        AI_Behavior = Random.Range(1, 8);
        if (AI_Behavior == 6 && health > 99)
        {
            AI_Behavior = 1;
        }
        //before the high rush attack, make repositioing true so chauv can walk to his charge point at the far end
        if (AI_Behavior == 4)
        {
            repositioning = true;
        }
    }

    public void PunchOne()
    {
        Instantiate(meleeHitBox, meleePos.transform.position, Quaternion.identity);
    }
    public void PunchTwo()
    {
        Instantiate(meleeHitBox, meleePos.transform.position + new Vector3(-1, 0,0), Quaternion.identity);
        Invoke("DecideNextAI", 1.2f);
    }
    public void BarrelRollPause()
    {
        //add the animation

        //barrelRolled = true;
        Invoke("BarrelRoll", 1.0f);
    }
    public void BarrelRoll()
    {
        Instantiate(barrel, transform.position + new Vector3(0, -3.9f, 0), Quaternion.identity);
        //barrelRolled = false;
        Invoke("GoToAI1", 4.0f);
    }
    public void GoToAI1()//go back to walking around after releasing barrels
    {
        AI_Behavior = 1;
        barrelRolled = false;
        canonShot = false;flyingUp = 1;

        //8
        impacted = false;
    }

    public void CanonShotPause()
    {
        //add the animation

        //barrelRolled = true;
        Invoke("CanonShoot", 1.0f);
    }
    public void CanonShoot()
    {
        canonShooting = true;
    }

    public void CanonStop()
    {
        canonShot = false;
        AI_Behavior = 2;
    }

    public void WaitTofly()
    {

    }
}
