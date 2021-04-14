using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class umberallHereScript : MonoBehaviour
{
    Rigidbody rb;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        rb.AddForce(2, 500, 0);
        Debug.Log("The umbrella should be coming towards you");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) > .1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 10f * Time.deltaTime);
        } else
        {
            Destroy(this.gameObject);
        }
    }
}
