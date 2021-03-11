using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballJumperProjectileScript : MonoBehaviour
{
    Rigidbody rb;
    public float fireballJumpMag;
    public Vector3 fireballVelocityY;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.localEulerAngles = new Vector3(-90, 0, 0);
        
        rb.AddForce(0, fireballJumpMag, 0);
    }

    // Update is called once per frame
    void Update()
    {
        fireballVelocityY = rb.velocity;
        if(fireballVelocityY.y < 0)
        {
            transform.localEulerAngles = new Vector3(90,0, 0);
        }
    }
}
