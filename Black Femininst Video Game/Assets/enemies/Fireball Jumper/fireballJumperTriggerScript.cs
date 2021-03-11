using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballJumperTriggerScript : MonoBehaviour
{
    public GameObject fireballJumper;
    private bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(activated == false)
            {
                fireballJumper.GetComponent<fireballJumperScript>().activated = true;
                fireballJumper.GetComponent<fireballJumperScript>().ShootFireball();
                activated = true;
            }
            
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fireballJumper.GetComponent<fireballJumperScript>().activated = false;
            Invoke("ReActivate", 10f);
            
        }
    }
    void ReActivate()
    {
        activated = false;
    }
}
