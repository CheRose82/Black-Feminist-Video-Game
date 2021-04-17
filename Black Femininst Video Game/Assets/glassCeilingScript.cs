using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glassCeilingScript : MonoBehaviour
{
    public GameObject glassPart;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(glassPart, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
