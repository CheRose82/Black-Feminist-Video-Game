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
    public GameObject player;
    public GameObject sabine;
    public GameObject dialogBoxRun;
    public int AIBehavior;
    public float speed;
    public bool runawayStarted;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        AIBehavior = 1;
        speed = 0.03f;
    }

    // Update is called once per frame
    void Update()
    {
        //idle
        if(AIBehavior == 1)
        {
            //set animation to idle
        }

        //running without tail
        if(AIBehavior == 2)
        {
            if (Vector3.Distance(transform.position, player.transform.position) >12f)
            {
                transform.Translate(-speed, 0, 0);
                //set animation to running with tail
            }
            else
            {
                AIBehavior = 1;
            }
        }

        //running with tail
        if(AIBehavior == 3)
        {
            //set run with hair animation
            transform.Translate(speed, 0, 0);


        }

        if(AIBehavior == 4)
        {
            //fire glitter bomb animation
        }

        if (AIBehavior == 5)
        {
            //fire kicking animation
        }

        if(AIBehavior == 6)// Run away to next location after being petted by Sabine
        {
            if(runawayStarted == false)
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
            }
            else
            {
                //turn back around
                AIBehavior = 1;
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

    }
}
