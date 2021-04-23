using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startHorseParticles : MonoBehaviour
{
    public GameObject uniPos;
    public GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        uniPos = GameObject.Find("UniPos");
        spawner = GameObject.Find("HorseParticleSpawner");
        spawner.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spawner.SetActive(true);
        }
    }
}
