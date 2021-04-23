using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamControllerScipt : MonoBehaviour
{
    public GameObject cam;


    //cam 1 scroll forward
    //cam 2 scroll forward plus up and down
    //cam 3 teleport to location and be still
    //cam 4 zoom
    //cam 5 be still at current location

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3);
        }
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

            if(other.GetComponent<cameraSwitchPlaneScript>().CamBehavior == 5)
            {
                //cam.transform.position = cam.transform.position;
            }
        }
    }
}
