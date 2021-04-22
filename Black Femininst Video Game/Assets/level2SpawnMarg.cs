using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2SpawnMarg : MonoBehaviour
{

    public GameObject marg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            marg.GetComponent<MargLevel4Script>().PoofIn();
        }
    }

}
