using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabineForrestScript : MonoBehaviour
{
    public GameObject unicorn;
    public GameObject pettingDB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BlackUnicorn"))
        {
            //enable the petting animation
            Invoke("TalkAfterPetting", 2f);

        }
    }

    public void TalkAfterPetting()
    {
        pettingDB.transform.position = this.gameObject.transform.position + new Vector3(0, 10, 0);
        pettingDB.GetComponent<Rigidbody>().useGravity = true;
    }
}
