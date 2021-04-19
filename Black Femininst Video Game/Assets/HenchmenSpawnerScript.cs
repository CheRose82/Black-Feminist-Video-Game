using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HenchmenSpawnerScript : MonoBehaviour
{
    public GameObject henchmen;
    public GameObject DBp57WhoAreThey;
    public GameObject chauv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(henchmen, transform.position + new Vector3(0, 20, 0), Quaternion.identity);
            Instantiate(henchmen, transform.position + new Vector3(-3, 20, 0), Quaternion.identity);
            Instantiate(henchmen, transform.position + new Vector3(6, 20, 0), Quaternion.identity);
            Instantiate(henchmen, transform.position + new Vector3(10, 20, 0), Quaternion.identity);
            chauv.GetComponent<ChauvanimsusScript>().AI_Behavior = 1;
            Destroy(this.gameObject);
        }
    }
}
