using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swayScript2 : MonoBehaviour
{
    
    public float zRotMagnitude;
    public float zRotFrequency;

    public float zRot;
    public float yRot;
    public float leftRight;

    // Start is called before the first frame update
    void Start()
    {
        zRotMagnitude = .05f;
        zRotFrequency = Random.Range(.45f, .55f);
        leftRight = Random.Range(0f, 1f);
        if(leftRight > .5f)
        {
            yRot = 0;
        }
        else
        {
            yRot = 180f;
        }

        transform.position = new Vector3(Random.Range(-40f, 40f), transform.position.y, Random.Range(-6f, 20f));

        transform.eulerAngles = new Vector3(0, yRot, Random.Range(-10f, -12.5f));
        
    }

    // Update is called once per frame
    void Update()
    {
        zRot = Mathf.Sin(zRotFrequency * Time.time) * zRotMagnitude;
        transform.Rotate(0, 0, zRot);
    }
}
