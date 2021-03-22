using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition1 : MonoBehaviour
{
    //Cam 1 + 2
    public Transform player;
    public Vector3 offset;
    //Added float offset to change x position of camera for camera 1. 
    public float cameraXOffset;

    public float smoothSpeed = 0.125f;
    public float smoothFactor = 1;
    public Camera Cam;

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
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        if (Cam_Behavior == 1)
        {
            //Used your guide for true and added the float offset for x for the player's position on the x axis.
            //This allows the player to see more of whats ahead and to the right.
            if (player.GetComponent<playerScript>().facingRight == true)
            {
                Vector3 playerPosition = player.position + offset;
                Vector3 newPosition = new Vector3(player.position.x + cameraXOffset, transform.position.y, -13f);
                transform.position = Vector3.Lerp(transform.position, newPosition, smoothSpeed * Time.deltaTime);
            }
            //The player can turn around and go left and still have room to see whats to the left. The camera quickly switches.
            //Kept the code the same as above except I didnt add the cameraXOffset.
            if (player.GetComponent<playerScript>().facingRight == false)
            {
                Vector3 playerPosition = player.position + offset;
                Vector3 newPosition = new Vector3(player.position.x, transform.position.y, -13f);
                transform.position = Vector3.Lerp(transform.position, newPosition, smoothSpeed * Time.deltaTime);
            }
        }
        if (Cam_Behavior == 2)
        {
            Vector3 playerPosition = player.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, playerPosition, smoothFactor * Time.fixedDeltaTime);
            transform.position = smoothPosition;
        }
        if (Cam_Behavior == 3)
        {   //Added this to allow the player to move smoothly as it goes through each frame.
            //Am not sure if this is needed but I knew I couldnt have the OnTriggerEnter inside the LateUpdate() 
            //so I added a transform.position to move the player.

            //transform.position = Vector3.Lerp(transform.position, player.transform.position, smoothSpeed * Time.deltaTime);
        }
        if (Cam_Behavior == 4 && Zoom)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Speed);

        }
    }

    //Added a OnTriggerEnter and tagged the empty game objects "Frames" but didnt know if I needed to add that or Player.
    //I put player as the tag below because I assumed it needed to be that since the player is the one going through each frame.
    
     //void OnTriggerEnter(Collider other)
     //{
     //   if (other.CompareTag("Player"))
     //   {

     //This was where I was stuck, I had trouble finding the way to move the camera to follow the gameObject.
     //       Cam.transform.position = gameObject;
     //   }
}

