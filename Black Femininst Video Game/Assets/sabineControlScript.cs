using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sabineControlScript : MonoBehaviour
{
    Rigidbody rb;
    public float runSpeed;
    public bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        runSpeed = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        //walk left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-runSpeed, 0, 0);
        }

        //walk right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(runSpeed, 0, 0);
        }

        //jump
        if (grounded)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.velocity = Vector3.up * 7.5f;
            }
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
