using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HenchmenSpawnerScript : MonoBehaviour
{
    public GameObject henchmen;
    public GameObject DBp57WhoAreThey;

    public GameObject dbQuickIneed;

    public GameObject DBAreThoseInternetTrolls;

    public GameObject chauv;

    public GameObject AxeL4;
    public int iteration;
    // Start is called before the first frame update
    void Start()
    {
        iteration = 1;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(iteration == 1)
            {
                Instantiate(henchmen, transform.position + new Vector3(0, 20, 0), Quaternion.identity);
                Instantiate(henchmen, transform.position + new Vector3(-3, 20, 0), Quaternion.identity);
                Instantiate(henchmen, transform.position + new Vector3(6, 20, 0), Quaternion.identity);
                Instantiate(henchmen, transform.position + new Vector3(10, 20, 0), Quaternion.identity);
                Invoke(nameof(Iteration2), 8);

                Instantiate(DBAreThoseInternetTrolls, transform.position, Quaternion.identity);

                Invoke(nameof(Iteration2), 8);

            }

            if(iteration == 2)
            {
                Instantiate(henchmen, transform.position + new Vector3(0, 20, 0), Quaternion.identity);
                Instantiate(henchmen, transform.position + new Vector3(-3, 20, 0), Quaternion.identity);
                Instantiate(henchmen, transform.position + new Vector3(6, 20, 0), Quaternion.identity);
                Instantiate(henchmen, transform.position + new Vector3(10, 20, 0), Quaternion.identity);

                Instantiate(henchmen, transform.position + new Vector3(0, 20, 0), Quaternion.identity);
                Instantiate(henchmen, transform.position + new Vector3(-3, 20, 0), Quaternion.identity);
                Instantiate(henchmen, transform.position + new Vector3(6, 20, 0), Quaternion.identity);
                Instantiate(henchmen, transform.position + new Vector3(10, 20, 0), Quaternion.identity);

                Instantiate(henchmen, transform.position + new Vector3(0, 20, 0), Quaternion.identity);
                Instantiate(henchmen, transform.position + new Vector3(-3, 20, 0), Quaternion.identity);
                Instantiate(henchmen, transform.position + new Vector3(6, 20, 0), Quaternion.identity);
                Instantiate(henchmen, transform.position + new Vector3(10, 20, 0), Quaternion.identity);


                Instantiate(henchmen, transform.position + new Vector3(0, 20, 0), Quaternion.identity);
                Instantiate(henchmen, transform.position + new Vector3(-3, 20, 0), Quaternion.identity);
                Instantiate(henchmen, transform.position + new Vector3(6, 20, 0), Quaternion.identity);
                Instantiate(henchmen, transform.position + new Vector3(10, 20, 0), Quaternion.identity);

                Instantiate(dbQuickIneed, transform.position, Quaternion.identity);
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;

                
            }
            
        }
    }

    public void Iteration2()
    {
        iteration = 2;
    }

    public void GiveAxeL4()
    {
        Instantiate(AxeL4, transform.position, Quaternion.identity);
    }
}
