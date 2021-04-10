using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundSpawnerController : MonoBehaviour
{
    public GameObject sp1;
    public GameObject sp2;
    public GameObject sp3;
    public GameObject sp4;
    public GameObject sp5;
    public GameObject sp6;
    public GameObject sp7;

    public void SpawnSound()
    {
        sp1.GetComponent<soundSpawnerScript>().activated = true;
        sp2.GetComponent<soundSpawnerScript>().activated = true;
        sp3.GetComponent<soundSpawnerScript>().activated = true;
        sp4.GetComponent<soundSpawnerScript>().activated = true;
        sp5.GetComponent<soundSpawnerScript>().activated = true;
        sp6.GetComponent<soundSpawnerScript>().activated = true;
        sp7.GetComponent<soundSpawnerScript>().activated = true;
    }

    public void StopSpawnSound()
    {
        sp1.GetComponent<soundSpawnerScript>().activated = false;
        sp2.GetComponent<soundSpawnerScript>().activated = false;
        sp3.GetComponent<soundSpawnerScript>().activated = false;
        sp4.GetComponent<soundSpawnerScript>().activated = false;
        sp5.GetComponent<soundSpawnerScript>().activated = false;
        sp6.GetComponent<soundSpawnerScript>().activated = false;
        sp7.GetComponent<soundSpawnerScript>().activated = false;
    }
}
