using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFixScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Invoke("FixTree", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixTree()
    {
        this.gameObject.GetComponent<swayScript2>().zRotMagnitude = Random.Range(.004f, .006f);
        transform.eulerAngles = new Vector3(0, GetComponent<swayScript2>().yRot, Random.Range(-1f, -2f));
    }
}
