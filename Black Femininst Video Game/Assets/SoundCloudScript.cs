using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCloudScript : MonoBehaviour
{
    public bool goingLeft;
    public bool activated;
    public float speed;
    public float driftTime;
    // Start is called before the first frame update
    void Start()
    {
        driftTime = Random.Range(10f, 12f);
        speed = .01f;
        speed = Random.Range(.009f, .011f);
        

    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            driftTime -= Time.deltaTime;
            //move it in the desired direction
            if (goingLeft == true)
            {
                transform.Translate(speed * -1, 0, 0);
            }
            else
            {
                transform.Translate(speed * 1, 0, 0);
            }

            //slow down towards the end
            if (driftTime < 1.5f)
            {
                speed = speed * .982f;

                if(driftTime <= 0)
                {
                    activated = false;
                }
            }
        }

        //just for testing
        if (Input.GetKey(KeyCode.Space))
        {
            Invoke("StartDrifting", Random.Range(.01f, 2f));
        }


    }

    public void StartDrifting()
    {
        activated = true;
    }
}
