using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingRoadScript : MonoBehaviour
{
    public bool moving;
    public Transform baseRot;
    public Vector3 basePos;
    private float yPos;
    public BoxCollider coll;
    public GameObject player;
    public GameObject child;
    public float moveSpeed;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find
        coll = GetComponent<BoxCollider>();
        //make the colliders go away so that 
        coll.enabled = false;
        moving = false;

        //grab the yPos
        yPos = transform.position.y;

        //grab the base rotation and position
        baseRot = child.transform;
        child.transform.parent = null;
        basePos = this.transform.position;

        //start below the ground with a random rotation
        transform.Translate(0, -10, Random.Range(-10, 10));
        transform.localEulerAngles = new Vector3(Random.Range(0f, 270f), Random.Range(0f, 270f), Random.Range(0f, 270f));

        moveSpeed = 19.50f;
        rotateSpeed = 200f;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x - player.transform.position.x < 5)
        {
            moving = true;
            Debug.Log("moving should be true");
        }

        if(moving == true)//once activated it should move an rotate into position
        {
            //move it towards its initial position
            transform.position = Vector3.MoveTowards(transform.position, basePos, moveSpeed * Time.deltaTime);

            //rotate it towards its  rotation
            var step = rotateSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, child.transform.rotation, step);
            Debug.Log("The transform should be " + baseRot);

            if (transform.position.y - yPos < 0.2f)
            {
                coll.enabled = true;
            }
        }
    }
}
