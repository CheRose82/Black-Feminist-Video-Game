using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MargLevel2 : MonoBehaviour
{
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
        if (other.CompareTag("Player"))
        {
            // make it visible
            transform.position = new Vector3(243.76f, 7.55f, 0);
        }
    }

    public void DestroyMargL2()
    {
        Destroy(this.gameObject);
    }
}
