using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sabineControlScript : MonoBehaviour
{
    Rigidbody rb;
    public float runSpeed;
    public bool grounded;
    public GameObject SabineAnim;
    public Animator anim;


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
            //anim.SetBool("isRunning", true);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("isRunning", true);
            SabineAnim.transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("isRunning", false);
        }

        //walk right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(runSpeed, 0, 0);
            anim.SetBool("isRunning", true);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("isRunning", true);
            SabineAnim.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("isRunning", false);
        }


        //jump
        if (grounded)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.velocity = Vector3.up * 7.5f;
                anim.SetTrigger("jumpTrigger");
            }
        }

        //pet something. probably a horse
        if (Input.GetKeyDown(KeyCode.C))
        {
            anim.SetBool("isRunning", false);
            anim.SetTrigger("reachPet");
        }


    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            grounded = true;
            anim.SetBool("isOnGround", true);
        }

        //for level when she searches the toolbox
        if (other.CompareTag("ToolBoxSab"))
        {
            //start lookinh in box animation
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            grounded = false;
            anim.SetBool("isOnGround", false);
        }
    }
    public void Skel()
    {
        anim.SetTrigger("skeleton");
    }
}
