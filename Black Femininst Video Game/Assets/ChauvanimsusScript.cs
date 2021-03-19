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
    public bool movingLeft;
    private bool AI_1_Calc_Made;//have the calculations been made at the start of AI1
    public float walkSpeed;
    private float walkSpeedAdj;//I'll multiply the walkSpeed by this numberto make it go faster as he takes more damage
    //Actions:
    // 1 Walk back an forth
    // 2 Melee attack
    // 3 High charging attack
    // 4 Low charging attack
    // 5 Barrel Bomb

    // Start is called before the first frame update
    void Start()
    {
        AI_Behavior = 1;
        walkTimer = 5.0f;
        //walkSpeed = 0.1f;
        //movingLeft = true;
        walkSpeedAdj = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {

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

            }

            if(AI_1_Calc_Made == true)
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

            
        }
    }
}
