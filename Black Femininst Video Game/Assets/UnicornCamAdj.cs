using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicornCamAdj : MonoBehaviour
{
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Black Unicorn"))
        {
            cam.transform.position = new Vector3(245, 8.5f, -16.8f);
            cam.GetComponent<CameraPosition>().Cam_Behavior = 1;
        }
    }
}
