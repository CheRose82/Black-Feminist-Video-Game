using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRockScript : MonoBehaviour
{
    public float triggerLocY;
    public float triggerLocX;
    public GameObject rockTrigger;
    public GameObject collisionDust;
    Rigidbody rb;
    public SphereCollider sc1;
    public SphereCollider sc2;
    private bool touchingPlayer = false;
    Vector3 m_EulerAngleVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rockTrigger = Instantiate(rockTrigger, new Vector3(transform.position.x + triggerLocX, transform.position.y + triggerLocY, 0), transform.rotation);
        rockTrigger.GetComponent<FallingRockTriggerScript>().rock = this.gameObject;
        rb = GetComponent<Rigidbody>();
        m_EulerAngleVelocity = new Vector3(0, 0, 1000);

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.S))
        {
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
            Debug.Log("I pressed S");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground") && touchingPlayer == false)
        {
            sc1.enabled = false;
            sc2.enabled = false;
            rb.useGravity = false;
            Debug.Log("The ground was touched");
            Instantiate(collisionDust, transform.position, Quaternion.identity);
        }
        if (other.CompareTag("Player"))
        {
            if(touchingPlayer == false)
            {
                //sc1.enabled = false;
                sc2.enabled = false;
                touchingPlayer = true;
                if(transform.position.x > other.transform.position.x)
                {
                    rb.AddForce(300, 50, 0);
                }
                else
                {
                    rb.AddForce(-300, 50, 0);
                }
                Debug.Log("It should've moved to the right");
            }
            
        }

        //to make the rock become still once it passes through the Player
        //if the colliders are already false enabled
        if (other.CompareTag("Ground") && touchingPlayer == true)
        {
            //this should the rock cold in it's tracks
            rb.velocity = Vector3.zero;
            rb.AddForce(0, 50, 0);
            rb.angularVelocity = new Vector3(0, 0, 9000);
            //Invoke("Killgravity", 1.3f);
            Debug.Log("The rock should be stopped");
            //if it works maybe I could add a little and twist afterward
        }
    }
    public void RockFall()
    {
        rb.useGravity = true;
        rb.AddForce(0, -300, 0);
        Destroy(rockTrigger);
    }

    public void KillGravity()
    {
        rb.useGravity = false;
    }
}
