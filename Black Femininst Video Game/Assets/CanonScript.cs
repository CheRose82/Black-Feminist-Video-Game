using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonScript : MonoBehaviour
{
    private float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 1.1f;
        Invoke("Die", 4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed, 0, 0);
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
