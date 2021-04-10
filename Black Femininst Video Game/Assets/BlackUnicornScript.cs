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

    public int AIBehavior;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
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
            transform.Translate(-speed, 0, 0);
            //set animation to running without tail
        }

        //running with tail
        if(AIBehavior == 3)
        {
            transform.Translate(-speed, 0, 0);
            //set animation to running with tail
        }

        if(AIBehavior == 4)
        {
            //fire glitter bomb animation
        }

        if (AIBehavior == 5)
        {
            //fire kicking animation
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
}
