using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bewareSignScript : MonoBehaviour
{
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
        if (other.CompareTag("Sabine"))
        {
            transform.localScale = new Vector3(3, 3, 1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Sabine"))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
