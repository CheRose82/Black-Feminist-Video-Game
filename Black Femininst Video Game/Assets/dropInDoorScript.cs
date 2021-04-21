using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropInDoorScript : MonoBehaviour
{
    public Animator anim;
    public GameObject sabine;
    public float openDistance;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sabine = GameObject.Find("Sabine");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, sabine.transform.position) < openDistance)
        {
            anim.SetTrigger("openDoor");
        }
    }
}
