using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beginningDoorScript : MonoBehaviour
{
    public GameObject moveTowObj;
    public GameObject firstStep;
    public float moveSpeed;
    public bool stepBool;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 6.0f;
        stepBool = firstStep.GetComponent<RisingRoadScript>().moving;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("step bool " + stepBool);
        if(firstStep.GetComponent<RisingRoadScript>().moving == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveTowObj.transform.position, moveSpeed * Time.deltaTime);
            Debug.Log("The door should be moving");
        }
    }
}
