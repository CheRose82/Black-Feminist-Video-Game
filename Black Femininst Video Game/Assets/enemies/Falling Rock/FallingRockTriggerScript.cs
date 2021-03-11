using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRockTriggerScript : MonoBehaviour
{
    public GameObject rock;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rock.GetComponent<FallingRockScript>().RockFall();
        }
    }
}
