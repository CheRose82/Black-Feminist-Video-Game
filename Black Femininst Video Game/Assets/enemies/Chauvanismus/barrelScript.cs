using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelScript : MonoBehaviour
{
    public GameObject leftBoundary;
    public float barrelSpeed;
    public bool movingLeft = true;
    public float explosionTimer;
    public GameObject expl;

    // Start is called before the first frame update
    void Start()
    {
        movingLeft = true;
        barrelSpeed = .05f;

        //rotate is to face the right way
        transform.localEulerAngles = new Vector3(-90, 0, 0);
        explosionTimer = Random.Range(2.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //countdown till it explodes\
        explosionTimer -= Time.deltaTime;
        if(explosionTimer < 0)
        {
            Explode();
        }

        if (movingLeft)
        {
            transform.Translate(-barrelSpeed, 0, 0);
        }
        else
        {
            transform.Translate(barrelSpeed, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Left Barrel Boundary"))
        {
            movingLeft = false;
        }
    }

    public void Explode()
    {
        Instantiate(expl, transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);
        Destroy(this.gameObject);
    }
}
