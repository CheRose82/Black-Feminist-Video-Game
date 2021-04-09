using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyBallGroundScript : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public GameObject regExplosion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 8.5f;
        Invoke("Die", 5.0f);
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crawler") || other.CompareTag("JumpAndThrow"))
        {
            Instantiate(regExplosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }


}
