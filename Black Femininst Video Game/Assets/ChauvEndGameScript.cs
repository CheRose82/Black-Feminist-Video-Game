using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChauvEndGameScript : MonoBehaviour
{
    public int health = 3;

    public GameObject dbIamAMan;
    public GameObject DBEnd;
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
        if(other.CompareTag("Energy Ball"))
        {
            if(health > 1)
            {
                health--;
                Instantiate(dbIamAMan, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(DBEnd, transform.position, Quaternion.identity);
            }

        }
    }
}
