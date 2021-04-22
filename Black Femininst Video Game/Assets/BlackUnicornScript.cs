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
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        AIBehavior = 1;
        speed = 0.03f;

        //if on level 2, invoke the functions to runoff screen
        Invoke(nameof(SayGoodbye), 2f);
        Invoke(nameof(Level2RunOff), 3.5f);
        if(level ==2)
        {
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
                GoIdle();
            }

            //running without tail
            if (AIBehavior == 2)
            {
                if (Vector3.Distance(transform.position, player.transform.position) > 12f)
                {
                    transform.Translate(-speed, 0, 0);
                    //set animation to running with tail
                    StopIdle();
                    anim.SetBool("isRunning", true);
                    anim.SetBool("hasTail", false);

                }
                else
                {
                    AIBehavior = 1;
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

            if (AIBehavior == 4)
            {
                //fire glitter bomb animation
                StopIdle();
                anim.SetTrigger("isSneezing");
                Invoke(nameof(GoIdle), 1);
            }

            if (AIBehavior == 5)
            {
                //fire kicking animation
                StopIdle();
                anim.SetTrigger("kickTrigger");
                Invoke(nameof(GoIdle), 1);
            }

            if (AIBehavior == 6)// Run away to next location after being petted by Sabine
            {
                if (runawayStarted == false)
                {
                    //enable run with animation
                    //turn around

                    //drop the dialogue box onto sabine\
                    dialogBoxRun.transform.position = sabine.transform.position + new Vector3(0, 10, 0);
                    dialogBoxRun.GetComponent<Rigidbody>().useGravity = true;
                }


                if (Vector3.Distance(transform.position, player.transform.position) < 35f)
                {
                    transform.Translate(speed, 0, 0);
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

    }

    //public void SetUnicornBehavior(int behavior)
    //{
    //    AIBehavior = behavior;
    //}

    public void Idle()
    {
        AIBehavior = 1;
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
        unicornAnim.transform.localEulerAngles = new Vector3(0, 180, 0);
    }
    public void StopIdle()
    {
        anim.SetBool("isIdle", false);
        //unicornAnim.transform.localEulerAngles = new Vector3(0, 0, 0);
    }

}
