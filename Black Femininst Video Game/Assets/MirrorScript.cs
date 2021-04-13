using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorScript : MonoBehaviour
{
    public Vector3 thisPos;
    public float riseSpeed;
    public int behavior;

    //behaviors
    //0 nothing
    //1 rising
    // Start is called before the first frame update
    void Start()
    {
        thisPos = this.transform.position;
        transform.Translate(0, -15, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(behavior == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, thisPos, riseSpeed * Time.deltaTime);

            //if it gets to the location  we stop it
            if(Vector3.Distance(transform.position, thisPos) < .05)
            {
                behavior = 0;
                GetComponentInChildren<MirrorHover>().enabled = true;
            }
        }
    }

    public void BeginRising()
    {
        behavior = 1;
    }
    public void RandomRise()
    {
        Invoke(nameof(BeginRising), Random.Range(0f, 0.5f));
    }
}
