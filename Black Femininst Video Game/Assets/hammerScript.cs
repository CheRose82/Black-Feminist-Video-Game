using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerScript : MonoBehaviour
{
    Rigidbody rb;
    private bool falling;
    public bool rising;
    public float riseSpeed;
    public GameObject player;
    public GameObject sabine;
    public Camera cam;
    public GameObject glassPart;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        sabine = GameObject.Find("Sabine");
        
        rb = GetComponent<Rigidbody>();
        falling = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (falling)
        {
            if (transform.position.y < 3.33f)
            {
                transform.position = new Vector3(transform.position.x, 3.33f, transform.position.z);
                rb.velocity = Vector3.zero;
                rb.useGravity = false;
                falling = false;
                GrabChildren();
            }
        }

        if (rising)
        {
            transform.Translate(0, riseSpeed, 0);
            if(riseSpeed < .1f)
            {
                riseSpeed = riseSpeed + .01f;
            }
        }
      
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Glass Ceiling"))
        {
            Instantiate(glassPart, transform.position, Quaternion.identity);
        }
    }

    public void GrabChildren()
    {
        player.transform.parent = this.gameObject.transform;
        player.GetComponent<Rigidbody>().useGravity = false;
        sabine.transform.parent = this.gameObject.transform;
        sabine.GetComponent<Rigidbody>().useGravity = false;

        //cam.transform.parent = this.gameObject.transform;
    }

    public void BreakCeiling()
    {
        Invoke(nameof(Rise), 4.0f);
    }

    public void Rise()
    {
        rising = true;
    }
}
