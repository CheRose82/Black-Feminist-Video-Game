using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition1 : MonoBehaviour
{
    //Cam 1 + 2
    public Transform player;
    public Vector3 offset;
    public float smoothSpeed = 0.125f; 
    public float smoothFactor = 1;
    public Camera Cam;

    //Cam 3
    public float yMax;
    public float yMin;
    public float xMax;
    public float xMin;

    //Cam 4
    public Transform target;
    public bool Zoom;
    public float Speed;

    public int Cam_Behavior = 1;

    //Cam_Behaviors
    //1 - follows player right
    //2 - follows player right, up, down
    //3 - camera clicks to frame
    //4 - slowly zooms to specific object

    void Start()
    {
        Cam = Camera.main;   
    }

    void LateUpdate()
    {
        if (Cam_Behavior == 1)
        {
            if(player.GetComponent<playerScript>().facingRight == true)
            {
                Vector3 playerPosition = player.position + offset;
                Vector3 newPosition = new Vector3(player.position.x, transform.position.y, -13f);
                transform.position = Vector3.Lerp(transform.position, newPosition, smoothSpeed * Time.deltaTime);
            }
            
            
            //Vector3 SmoothPosition = Vector3.Lerp(transform.position, playerPosition, smoothSpeed);
            //transform.position = SmoothPosition;

            //Vector3 playerPosition = player.position + offset;
            //Vector3 newPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);
            //transform.position = Vector3.Lerp(transform.position, newPosition, smoothFactor * Time.fixedDeltaTime);

            //if (camera.pos > max) camera.pos = max;
            // (camera.pos<min) camera.pos = min;
        }
        if (Cam_Behavior == 2)
        {
            Vector3 playerPosition = player.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, playerPosition, smoothFactor * Time.fixedDeltaTime);
            transform.position = smoothPosition;
        }
        if (Cam_Behavior == 3)
        {
            //Vector3 playerPosition = player.position + offset;
            //Cam.player.position = Vector3.Lerp(player.position, playerPosition.player.position, speed * Time.deltaTime);





            //Camera locks onto player when in frame
            if (player.transform.position.y < yMax && player.transform.position.y > yMin)
            {
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -13f);
            } 
            if (player.transform.position.y > yMax)
            {
                transform.position = new Vector3(player.transform.position.x, yMax, -13f);
            }
            if (player.transform.position.y < yMin)
            {
                transform.position = new Vector3(player.transform.position.x, yMin, -13f);
            }

            //Camera locks to next frame
            if (player.transform.position.x > xMax)
            {
                transform.position = new Vector3(xMax, player.transform.position.y, -13f);
            }
            if (player.transform.position.x < xMin)
            {
                transform.position = new Vector3(xMin, player.transform.position.y, -13f);
            }

           //transform.position = player.transform.position + new Vector3(0, 0, -13f);
        }
        if (Cam_Behavior == 4 && Zoom)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Speed);

        }
    }

    public void UpdateCam3()
    {
        //transform.positin = new Vector3(other + offset)
    }

}
