using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackoutTriggerScript : MonoBehaviour
{
    public GameObject blackoutBox;
    public GameObject mirrorCont;
    public GameObject jonasSquealsDB;
    // Start is called before the first frame update
    void Start()
    {
        blackoutBox = GameObject.Find("Blackout");
        mirrorCont = GameObject.Find("MirrorController");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //make th blackout vsiisble and the mirrors invisible
            blackoutBox.GetComponent<blackoutBoxScript>().Blackout();
            mirrorCont.GetComponent<MirrorControllerScript>().BlackoutMirrors();

            //start the Jonas Squeals dialogue tree
            Invoke(nameof(JonasSquealing), 1.5f);


            //move the box awat so that we can't hit it agai
            transform.Translate(0, 100, 0);
        }
    }

    public void JonasSquealing()
    {
        Instantiate(jonasSquealsDB, transform.position, Quaternion.identity);
    }
}
