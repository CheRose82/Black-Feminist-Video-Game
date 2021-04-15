using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabineLevel4 : MonoBehaviour
{ public GameObject key;


    public void ThrowKey()
    {
        Instantiate(key, transform.position, Quaternion.identity);
    }
}
