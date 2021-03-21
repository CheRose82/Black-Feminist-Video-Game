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
    public bool LowChargeAdj;


    //Actions:
    // 1 Walk back an forth
    // 2 deciding
    // 3 Melee attack
    // 4 High charging attack
    // 5 Low charging attack
    // 6 Barrel Bomb

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

}

    // Update is called once per frame
    void Update()
    {
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
                    if (Vector3.Distance(this.gameObject.transform.position, rightBoundary.transform.position) < 6 || Vector3.Distance(this.gameObject.transform.position, walkBoundary.transform.position) < 8)
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
                    Debug.Log("walk timer became less than zero");
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
            Debug.Log("We decided");
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
                transform.position = Vector3.MoveTowards(transform.position, rightBoundary.transform.position + new Vector3(-4.5f, ChauvHeight, 0), walkSpeed * 3);

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
                    transform.position = Vector3.MoveTowards(transform.position, walkBoundary.transform.position + new Vector3(-2f, ChauvHeight, 0), walkSpeed * 2);
                    
                }
                else //when it stops return to the origin point on the right side fo the screen.
                {
                    transform.position = Vector3.MoveTowards(transform.position, rightBoundary.transform.position + new Vector3(-4.5f, ChauvHeight, 0), walkSpeed * 1.5f);
                    Debug.Log("chargingTimer is " + chargingTimer);
                    Debug.Log("distance between chauv and the rightborder is " + Vector3.Distance(transform.position, rightBoundary.transform.position));

                    if(Vector3.Distance(transform.position, rightBoundary.transform.position) < 8.5f)//the last number will change if you don't keep the exact same positioning 
                    {
                        AI_Behavior = 2;
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
                Debug.Log("Ducked");
                transform.position = new Vector3(transform.position.x, transform.position.y - 6f, transform.position.z);
                LowChargeAdj = true;
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
                    //once it goes back to the right: stop it, reset everything, and go back to AI_behavior 2
                    AI_Behavior = 0;
                    leftLowChargingTimer = leftLowChargingTimerReset;
                    rightLowchargingTimer = rightLowchargingTimerReset;
                    LowChargeAdj = true;
                }
                
            }
        }


    }

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
        AI_Behavior = 5;
        //AI_Behavior = Random.Range(1, 7);
        //if(AI_Behavior == 6 && health > 99)
        //{
        //    AI_Behavior = 1;
        //}
        //before the high rush attack, make repositioing true so chauv can walk to his charge point at the far end
        if(AI_Behavior == 4)
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
}
