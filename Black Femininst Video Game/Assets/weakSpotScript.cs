using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weakSpotScript : MonoBehaviour
{
    public GameObject owner;
    


    // Start is called before the first frame update
    void Start()
    {
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(owner.GetComponent<roamerScript>() != null)
            {
                owner.GetComponent<roamerScript>().GetJumpedOn();
            }
            else if(owner.GetComponent<crawlerScript>() != null)
            {
                owner.GetComponent < crawlerScript>().GetJumpedOn();
            }
            else if(owner.GetComponent<jumpAndThrowScript>() != null)
            {
                owner.GetComponent<jumpAndThrowScript>().GetJumpedOn();
            }
        }
    }
    
}
