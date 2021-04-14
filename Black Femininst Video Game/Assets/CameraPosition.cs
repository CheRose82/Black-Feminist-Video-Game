using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Transform player;
    public GameObject playerObj;
    public Vector3 offset;
    public Vector3 playerBox;
    public float smoothFactor = 1;
    public bool Zoom;
    public Camera Cam;
    public float Speed;
    public float dampTime = 0.6f;
    public Vector3 velocity = Vector3.zero;
    public int Cam_Behavior = 1;
    //Cam_Behaviors
    //1 - follows player right
    //2 - follows player right, up, down
    //3 - camera clicks to new location
    //4 - slowly zooms to specific object
    //5 = Camera stops where it is

    void Start()
    {
        Cam = Camera.main;
        //Camera.main.orthographic = true;
        //playerBox = calculatePlayerBox();
        
    }

    void LateUpdate()
    {
        if (Cam_Behavior == 1)
        {
            if(playerObj.GetComponent<playerScript>().facingRight == true)
            {
                Vector3 playerPosition = player.position + offset;
                Vector3 newPosition = new Vector3(player.position.x + 7.5f, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, newPosition, smoothFactor * Time.fixedDeltaTime);
            }
            else
            {
                Vector3 playerPosition = player.position + offset;
                Vector3 newPosition = new Vector3(player.position.x - 7.5f, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, newPosition, smoothFactor * Time.fixedDeltaTime);
            }


            
            
            //if (camera.pos > max) camera.pos = max;
            // (camera.pos<min) camera.pos = min;
        }
        if (Cam_Behavior == 2)
        {

            if(playerObj.GetComponent<playerScript>().facingRight == true)
            {
                Vector3 playerPosition = player.position + offset;
                Vector3 newPosition = new Vector3(player.position.x + 7.5f, player.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, newPosition, smoothFactor * Time.fixedDeltaTime);
            }
            else
            {
                Vector3 playerPosition = player.position + offset;
                Vector3 newPosition = new Vector3(player.position.x - 7.5f, player.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, newPosition, smoothFactor * Time.fixedDeltaTime);
            }
            

            //Vector3 smoothPosition = Vector3.Lerp(transform.position, playerPosition, smoothFactor * Time.fixedDeltaTime);
            //transform.position = smoothPosition;
        }
        if (Cam_Behavior == 3)
        {
            
            //click to the next location

            //Vector3 follow = player.transform.position;
            //float xDifference = Vector3.Distance(Vector3.right * transform.position.x, Vector3.right * follow.x);
            //float yDifference = Vector3.Distance(Vector3.up * transform.position.y, Vector3.up * follow.y);

            //Vector3 newPosition = transform.position;
            //if (Mathf.Abs(xDifference) >= playerBox.x)
            //{
            //    newPosition.x = follow.x;
            //}
            //if (Mathf.Abs(yDifference) >= playerBox.y)
            //{
            //    newPosition.y = follow.y;
            //}

            //newPosition = new Vector3(player.position.x, player.position.y, -10f);
            //transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, dampTime);

        }
        if (Cam_Behavior == 4 && Zoom)
        {
            //Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 4, Speed);
            //write a function that uses Vector.MoveTowards to slowly move the camera in or out for close up and pan outs.

        }

        if (Cam_Behavior == 6)
        {

            if (playerObj.GetComponent<playerScript>().facingRight == true)
            {
                Vector3 playerPosition = player.position + offset;
                Vector3 newPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, newPosition, smoothFactor * Time.fixedDeltaTime);
            }
            else
            {
                Vector3 playerPosition = player.position + offset;
                Vector3 newPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, newPosition, smoothFactor * Time.fixedDeltaTime);
            }


            //Vector3 smoothPosition = Vector3.Lerp(transform.position, playerPosition, smoothFactor * Time.fixedDeltaTime);
            //transform.position = smoothPosition;
        }
    }

    //Vector3 calculatePlayerBox()
    //{
    //    Rect aspect = Camera.main.pixelRect;
    //    Vector3 b = new Vector3(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
    //    b.x -= offset.x;
    //    b.y -= offset.y;
    //    return b;
    //}
   
}
