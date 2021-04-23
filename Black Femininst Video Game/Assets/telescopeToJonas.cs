using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class telescopeToJonas : MonoBehaviour
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
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 5 * Time.deltaTime);
    }
}
