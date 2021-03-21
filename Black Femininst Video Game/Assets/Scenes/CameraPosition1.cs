using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition1 : MonoBehaviour
{
    //Cam 1 + 2
    public Transform player;
    public Vector3 offset;
    public float cameraXOffset;
    public float smoothSpeed = 0.125f;
    public float smoothFactor = 1;
    public Camera Cam;


    //Cam 3
    //public Vector3 maxPos;
    //public Vector3 minPos;

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
            if (player.GetComponent<playerScript>().facingRight == true)
            {
                Vector3 playerPosition = player.position + offset;
                Vector3 newPosition = new Vector3(player.position.x + cameraXOffset, transform.position.y, -13f);
                transform.position = Vector3.Lerp(transform.position, newPosition, smoothSpeed * Time.deltaTime);
            }
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
        {
            //transform.position = Vector3.Lerp(transform.position, player.transform.position, smoothSpeed * Time.deltaTime);
        }
        if (Cam_Behavior == 4 && Zoom)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Speed);

        }
    }

     //void OnTriggerEnter(Collider other)
     //{
     //   if (other.CompareTag("Player"))
     //   {
     //       Cam.transform.position = gameObject;
     //   }
}

