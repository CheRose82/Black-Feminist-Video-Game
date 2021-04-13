using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class covenSign : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
//        Debug.Log("the distance should be " + Vector3.Distance(transform.position, player.transform.position));
        if(Vector3.Distance(transform.position, player.transform.position) < 6)
        {
            LiteSign();
        }
    }

    void LiteSign()
    {
        //make it light up
//        Debug.Log("the sign lit up");
    }
}
