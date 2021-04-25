using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bewareSignScript : MonoBehaviour
{
    public float smallX;
    public float smallY;
    public float smallZ;
    public float bigX;
    public float bigY;
    public float bigZ;
    public GameObject db;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sabine")|| other.CompareTag("Player"))
        {
            transform.localScale = new Vector3(bigX, bigY, bigZ);
            Instantiate(db, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Sabine"))
        {
            transform.localScale = new Vector3(smallX, smallY, smallZ);
        }
    }
}
