using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackoutBoxScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Blackout()
    {
        GetComponent<MeshRenderer>().enabled = true;
    }

    public void UnBlackout()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
}
