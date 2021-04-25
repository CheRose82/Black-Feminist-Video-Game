using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossDoorScript : MonoBehaviour
{
    public GameObject border;
    public GameObject player;
    public GameObject sabine;
    public GameObject magicPart;
    public bool doorFalling;
    // Start is called before the first frame update
    void Start()
    {
        border = GameObject.Find("Boss Border");
        player = GameObject.Find("Player");
        sabine = GameObject.Find("Sabine");
    }

    // Update is called once per frame
    void Update()
    {
        if(doorFalling == true)
        {
            border.transform.Translate(0, -.2f, 0);
        }
        if(border.transform.position.y < 7)
        {
            border.transform.position = new Vector3(border.transform.position.x, 7, border.transform.position.z);
            doorFalling = false;
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Destroy(this.gameObject);
        }
    }


    
    public void DoorVanish()//door vanishes and players get blasted into the level
    {
        Instantiate(magicPart, transform.position, Quaternion.identity);
        player.GetComponent<Rigidbody>().AddForce(700, 250, 0);
        sabine.GetComponent<Rigidbody>().AddForce(1200, 250, 0);
        doorFalling = true;
    }


}
