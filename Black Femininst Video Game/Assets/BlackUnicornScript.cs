using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackUnicornScript : MonoBehaviour
{
    //1 Idle
    //2 Running without tail
    //3 Running with tail
    //4 Glitter Bomb
    //5 Kick
    public GameObject unicornAnim;
    public Animator anim;
    public int level;
    public GameObject player;
    public GameObject sabine;
    public GameObject dialogBoxRun;
    public int AIBehavior;
    public float speed;
    public bool runawayStarted;
    public bool runStarted;
    public bool facingLeft;
    public GameObject DBAskHer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        AIBehavior = 1;
        speed = 0.03f;

        //if on level 2, invoke the functions to runoff screen
        Invoke(nameof(SayGoodbye), 2f);
        
        if(level ==2)
        {
            Invoke(nameof(Level2RunOff), 3.5f);
            Invoke(nameof(DestroyUnicorn), 10f);
        }

        GoIdle();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(level == 1 || level == 2)
        {
            //idle
            if (AIBehavior == 1)
            {
                //GoIdle();
            }

            //running without tail
            if (AIBehavior == 2)
            {
                if (Vector3.Distance(transform.position, player.transform.position) > 12f)
                {
                    if(facingLeft)
                    {
                        unicornAnim.transform.localEulerAngles = new Vector3(0, 0, 0);
                    }
                    transform.Translate(-speed, 0, 0);
                    //set animation to running with tail
                    StopIdle();
                    anim.SetBool("isRunning", true);
                    anim.SetBool("hasTail", false);

                }
                else
                {
                    AIBehavior = 1;
                    GoIdle();
                }
            }

            //running with tail
            if (AIBehavior == 3)
            {
                //set run with hair animation
                transform.Translate(speed, 0, 0);
                StopIdle();
                anim.SetBool("isRunning", true);
                anim.SetBool("hasTail", true);


            }

            //if (AIBehavior == 4)
            //{
            //    //fire glitter bomb animation
            //    StopIdle();
            //    anim.SetTrigger("issSneezing");
            //    Invoke(nameof(GoIdle), 1);
            //}

            //if (AIBehavior == 5)
            //{
            //    //fire kicking animation
            //    StopIdle();
            //    anim.SetBool("isKicking", true);
            //    Invoke(nameof(GoIdle), 1);
            //}

            if (AIBehavior == 6)// Run away to next location after being petted by Sabine
            {
                if (runawayStarted == false)
                {
                    //enable run with animation
                    //turn around

                    //drop the dialogue box onto sabine\
                    Instantiate(dialogBoxRun, transform.position, Quaternion.identity);
                }


                if (Vector3.Distance(transform.position, player.transform.position) < 35f)
                {
                    transform.Translate(speed + .02f, 0, 0);
                    //set animation to running with tail
                    StopIdle();
                    anim.SetBool("isRunning", true);
                    anim.SetBool("hasTail", true);

                }
                else
                {
                    //turn back around
                    AIBehavior = 1;
                }

            }

        }

        if(level == 2)
        {
            if(runawayStarted == true)
            {
                //run off
                transform.Translate(speed, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Level1Approach();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Instantiate(DBAskHer, transform.position, Quaternion.identity);
        }

    }

    //public void SetUnicornBehavior(int behavior)
    //{
    //    AIBehavior = behavior;
    //}

    public void Idle()
    {
        //AIBehavior = 1;
        anim.SetBool("isIdle", true);
    }

    public void NoTail()
    {
        AIBehavior = 2;
    }

    public void WithTail()
    {

    }

    public void GBomb()
    {
        //animation for glitter bomb
        //player.GetComponent<Rigidbody>().AddForce(-300, 70, 0);

        StopIdle();
        anim.transform.localEulerAngles = new Vector3(0, 0, 0);
        anim.SetBool("iisSneezing", true);
        Invoke(nameof(GoIdle), 1);
        Debug.Log("The glitter bomb happened on the horse side");
    }

    public void EndingRunOff()
    {
        AIBehavior = 3;
    }

    public void SayGoodbye()
    {
        //Call yeehaw animation for horse to say goodbye
        Debug.Log("Said Goodbye. nameof works");
    }

    public void Level2RunOff()
    {
        Invoke(nameof(Level2Run), 4);
    }
    public void Level2Run()
    {
        //seitch to running with Tail animation
        runawayStarted = true;
        AIBehavior = 3;
        //unicornAnim.transform.localEulerAngles = new Vector3(0, 180, 0);
    }

    public void DestroyUnicorn()
    {
        Destroy(this.gameObject);
    }

    public void GoIdle()
    {
        anim.SetBool("isIdle", true);
        anim.SetBool("isKicking", false);
        anim.SetBool("iisSneezing", false);
        unicornAnim.transform.localEulerAngles = new Vector3(0, 180, 0);
    }
    public void StopIdle()
    {
        anim.SetBool("isIdle", false);
        //unicornAnim.transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    public void Level1Approach()
    {
        facingLeft = true;
        AIBehavior = 2;
    }

    public void Kick()
    {
        //fire kicking animation
        StopIdle();
        anim.SetBool("isKicking", true);
        Invoke(nameof(GoIdle), 0.7f);
    }
}


