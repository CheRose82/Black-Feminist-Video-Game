using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorRotateScript : MonoBehaviour
{
    public float turnSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, turnSpeed, 0);
    }
}
