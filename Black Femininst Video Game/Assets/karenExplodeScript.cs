using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karenExplodeScript : MonoBehaviour
{
    public GameObject jonas;
    public GameObject sabine;
    public bool recoiling;
    public GameObject db55Nooo;
    // Start is called before the first frame update
    void Start()
    {
        jonas = GameObject.Find("Player");
        sabine = GameObject.Find("Sabine");
    }

    void Update()
    {
        if (recoiling)
        {
            jonas.transform.position = Vector3.MoveTowards(jonas.transform.position, jonas.transform.position + new Vector3(-6, 0, 0), 3 * Time.deltaTime);
            sabine.transform.position = Vector3.MoveTowards(sabine.transform.position, sabine.transform.position + new Vector3(6, 0, 0), 3 * Time.deltaTime);
            
        }  
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            jonas.GetComponent<Rigidbody>().AddForce(-50, 150, 0);
            sabine.GetComponent<Rigidbody>().AddForce(50, 150, 0);
            Invoke(nameof(StopRecoiling), 1.5f);
           
        }
    }

    public void StopRecoiling()
    {
        recoiling = false;
    }
}
