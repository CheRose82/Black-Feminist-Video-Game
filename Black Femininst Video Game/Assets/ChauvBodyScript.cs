using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChauvBodyScript : MonoBehaviour
{
    public int numberHit;
    public GameObject DBp58IAmAMan;
    public GameObject DBp58HeySocialFam;
    public int cycles;
    // Start is called before the first frame update
    void Start()
    {
        numberHit = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Energy Ball"))
        {
            numberHit++;
            if(numberHit >= 5)
            {
                numberHit = 1;
                
                
                if(cycles < 3)
                {
                    Instantiate(DBp58IAmAMan, transform.position, Quaternion.identity);
                    cycles++;
                }
                else
                {
                    Instantiate(DBp58HeySocialFam, transform.position, Quaternion.identity);
                }
            }
        }
    }
}
