using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamControllerScipt : MonoBehaviour
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
       if(other.CompareTag("Camera Switch"))
        {
            cam.GetComponent<CameraPosition>().Cam_Behavior = other.GetComponent<cameraSwitchPlaneScript>().CamBehavior;
            if(other.GetComponent<cameraSwitchPlaneScript>().CamBehavior == 3)
            {
                cam.transform.position = other.GetComponent<cameraSwitchPlaneScript>().camLocation;
            }
        }
    }
}
