using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabineLevel2 : MonoBehaviour
{
    public GameObject hereUmb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void HereUmbrella()
    {
        Instantiate(hereUmb, transform.position, Quaternion.identity);
    }
}
