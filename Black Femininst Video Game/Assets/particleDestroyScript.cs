using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleDestroyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(EndParticle), 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndParticle()
    {
        Destroy(this.gameObject);
    }
}
