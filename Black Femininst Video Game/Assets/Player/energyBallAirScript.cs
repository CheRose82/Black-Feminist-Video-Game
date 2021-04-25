using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyBallAirScript : MonoBehaviour
{
    Rigidbody rb;
    private float speed;
    public float tiltSpeed;
    public GameObject regExplosion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 7.0f;
        //angle it up just a bit
        transform.Rotate(-20, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed;
        transform.Rotate(tiltSpeed, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground")|| other.CompareTag("JumpAndThrow"))
        {
            Instantiate(regExplosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Chauv"))
        {
            Instantiate(regExplosion, transform.position, Quaternion.identity);
            Invoke(nameof(Die), .1f);
        }


    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
