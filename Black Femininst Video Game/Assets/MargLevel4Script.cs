using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MargLevel4Script : MonoBehaviour
{
    public GameObject dbFinal;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(dbFinal, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
