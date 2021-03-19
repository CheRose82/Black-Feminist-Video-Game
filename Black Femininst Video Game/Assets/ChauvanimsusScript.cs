using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChauvanimsusScript : MonoBehaviour
{
    public GameObject body;//the big cube that will serve has primary hit box
    public GameObject player;
    public GameObject rightBoundary;//limit on how far right he can move. Can or cannot be visible
    public GameObject walkBoundary;//empty object that dictates how far left he will walk
    public int AI_Behavior;
    private int health;
    private float walkTimer;//how long he walks during AI_Behavior1
    private float walkTimerReset;
    public bool walking;
    public bool movingLeft;
    private bool AI_1_Calc_Made;//have the calculations been made at the start of AI1
    public float walkSpeed;
    private float walkSpeedAdj;//I'll multiply the walkSpeed by this numberto make it go faster as he takes more damage
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
                    if (Vector3.Distance(this.gameObject.transform.position, rightBoundary.transform.position) < 6 || Vector3.Distance(this.gameObject.transform.position, walkBoundary.transform.position) < 4)
                    {
                        walking = false;
                        Debug.Log("fuck it");

                        ChangeDir();
                        Invoke("WalkingTrue", 1.5f);
                    }
                }
                else
                {
                    AI_Behavior = 2;//deciding what to do next
                    walking = false;
                    walkTimer = walkTimerReset;
                }
            }
        }

        //deciding
        if(AI_Behavior == 2)
        {
            Invoke("DecideNextAI", 3.0f);
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
        AI_Behavior = Random.Range(0, 7);
        if(AI_Behavior == 6 && health < 100)
        {
            AI_Behavior = 1;
        }
    }
}
