using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class umbScript : MonoBehaviour
{
    public GameObject toolbox;
    public GameObject destinationObj;
    public bool activated;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = toolbox.transform.position + new Vector3(0, 2, 0);
        moveSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        //once actiaveted move towards its reveal location
        if (activated)
        {
            transform.position = Vector3.MoveTowards(transform.position, destinationObj.transform.position, moveSpeed * Time.deltaTime);
        }
        //make it stop once it gets there
        if (Vector3.Distance(transform.position, destinationObj.transform.position) < 0.1f)
        {
            activated = false;
        }
    }

    public void ActivateItem2()
    {
        //make it visible
        activated = true;
    }
}
