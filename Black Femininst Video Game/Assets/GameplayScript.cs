using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayScript : MonoBehaviour
{
    public int health;
    public bool TakingDamage = true;
    // Start is called before the first frame update
    void Start()
    {
        TakingDamage = true;
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crawler"))
        {
            Debug.Log("The trigger fired");
            if (TakingDamage)
            {
                TakeDamage(1);
                Debug.Log("taking damage was true");
            }
        }
    }
    void CheckDamage()
    {
        if(health < 1)
        {
            Debug.Break();
        }
    }
    public void TakeDamage(int damage)
    {
        health = health - damage;
        TakingDamage = false;
        Invoke("ActivateDamage", 1.5f);
        Debug.Log("TakeDamage() worked");
    }

    public void ActivateDamage()
    {
        TakingDamage = true;
    }
}
