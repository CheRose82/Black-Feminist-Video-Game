using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevel4Script : MonoBehaviour
{
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sabine"))
        {
            transform.localScale = new Vector3(3, 3, 1);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Sabine"))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void Footsteps()
    {
        //play the loud footsteps and make the screen shake
        Debug.Log("You'll hear footsteps the lights will break ");
    }
}
