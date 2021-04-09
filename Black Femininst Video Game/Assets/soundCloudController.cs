using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundCloudController : MonoBehaviour
{
    public GameObject sc1;
    public GameObject sc2;
    public GameObject sc3;
    public GameObject sc4;
    public GameObject sc5;
    public GameObject sc6;
    public GameObject sc7;
    public GameObject sc8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void StartSondCloud()
    {
        sc1.GetComponent<SoundCloudScript>().activated = true;
        sc2.GetComponent<SoundCloudScript>().activated = true;
        sc3.GetComponent<SoundCloudScript>().activated = true;
        sc4.GetComponent<SoundCloudScript>().activated = true;
        sc5.GetComponent<SoundCloudScript>().activated = true;
        sc6.GetComponent<SoundCloudScript>().activated = true;
        sc7.GetComponent<SoundCloudScript>().activated = true;
        sc8.GetComponent<SoundCloudScript>().activated = true;
    }
}
