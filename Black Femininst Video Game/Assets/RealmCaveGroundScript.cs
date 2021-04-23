using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealmCaveGroundScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
