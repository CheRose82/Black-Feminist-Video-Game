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

    public GameObject DBp60JonasAreYouAlright;
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
    public GameObject ChauvAnim;
    public Animator anim;


    void Start()
    {
        //AI_Behavior = 1;
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
        AI_Behavior = 0;

}

    // Update is called once per frame
    void Update()
    {
        // walk left
        if (Input.GetKey(KeyCode.T))
        {
            transform.Translate(-.15f, 0, 0);
        }

        // walk left
        if (Input.GetKey(KeyCode.Y))
        {
            transform.Translate(.15f, 0, 0);
        }
    

        //firing
        if(AI_Behavior == 2)
        {
            //anim.SetInteger("AIB", 3);
        }

        if(AI_Behavior == 9)//mirror jonas
        {
            float yPos = chauvCentralPos.y + (player.transform.position.y - jonasCentralPos.y) - 2;
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
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Instantiate(DBp60JonasAreYouAlright, transform.position, Quaternion.identity);
            GetComponent<Renderer>().enabled = false;
            Destroy(this.gameObject);
            
        }

        //Pig Face
        if (Input.GetKeyDown(KeyCode.O))
        {
            anim.SetInteger("AIB", 2);
            print("I pressed O");
        }

        //boobs
        if (Input.GetKeyDown(KeyCode.P))
        {
            anim.SetInteger("AIB", 3);
            print("I pressed P");
        }

        //Idle
        if (Input.GetKeyDown(KeyCode.U))
        {
            anim.SetInteger("AIB", 0);
            print("I pressed U");
        }

        //boobs
        if (Input.GetKeyDown(KeyCode.I))
        {
            anim.SetInteger("AIB", 1);
            print("I pressed I");
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

    

    

}
