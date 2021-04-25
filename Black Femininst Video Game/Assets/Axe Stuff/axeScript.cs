using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axeScript : MonoBehaviour
{
    public float yMag;
    public float yFreq;
    public float yPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yPos = Mathf.Sin(yFreq * Time.time) * yMag;
        transform.position = new Vector3(transform.position.x, yPos + 3.33f, transform.position.z);
    }
}
