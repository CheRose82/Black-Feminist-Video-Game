using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBoxScript : MonoBehaviour
{
    public GameObject moveTowardsObj;
    public bool activated;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //once actiaveted move towards its reveal location
        if (activated)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveTowardsObj.transform.position, moveSpeed * Time.deltaTime);
        }
        //make it stop once it gets there
        if(Vector3.Distance(transform.position, moveTowardsObj.transform.position) < 0.1f)
        {
            activated = false;
        }
    }

    public void ActivateToolBox()
    {
        activated = true;
    }
}
