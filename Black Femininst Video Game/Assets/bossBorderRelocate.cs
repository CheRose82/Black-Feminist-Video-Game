using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBorderRelocate : MonoBehaviour
{
    public GameObject bossBorder;
    public GameObject DBp57GrabJonas;
    // Start is called before the first frame update
    void Start()
    {
        bossBorder = GameObject.Find("Boss Border");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bossBorder.transform.position = new Vector3(bossBorder.transform.position.x, 7.21f, bossBorder.transform.position.z);
            Instantiate(DBp57GrabJonas, transform.position, Quaternion.identity);
        }
    }
}
