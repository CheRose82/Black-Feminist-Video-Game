using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestScript : MonoBehaviour
{
    public float runSpeed;
    public GameObject sprite;
    public GameObject nicole;
    public bool Grounded;
    public bool walking;
    public Animator anim;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        runSpeed = 0.05f;
        rb = GetComponent<Rigidbody>();
        nicole = GameObject.Find("Nicole");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-runSpeed, 0, 0);
        }
        
        //sss
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(runSpeed, 0, 0);
        }

        //trigger for the run anim
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetBool("Running", true);
            walking = true;

         
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("Running", false);
            walking = false;

        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("JumpingTrigger");
            rb.velocity = Vector3.up * 5;
        }

        //if statements for the horizontal flip
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            sprite.transform.localScale = new Vector3(1, 1, 1);
        }

        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            sprite.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            anim.SetBool("onGround", true);
            Grounded = true;
        }

        if (other.CompareTag("NicoleAct"))
        {
            nicole.GetComponent<NicoleNPCScript>().activated = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            anim.SetBool("onGround", false);
            Grounded = false;
        }
    }
}
