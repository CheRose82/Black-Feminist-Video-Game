using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayScript : MonoBehaviour
{
    public int health;
    public bool TakingDamage = true;
    Rigidbody rb;
    public float recoil;
    // Start is called before the first frame update
    void Start()
    {
        TakingDamage = true;
        health = 3;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crawler"))
        {
            if (TakingDamage)
            {
                if (transform.position.x < other.transform.position.x)//he's getting hit from the right
                {
                    TakeDamage(1, -50, 200);
                }
                else
                {
                    TakeDamage(1, 50, 200);
                }
                GetComponent<playerScript>().LoseControl(0.7f);
            }
        }
        if (other.CompareTag("Roamer"))
        {
            if (TakingDamage)
            {
                if (transform.position.x < other.transform.position.x)//he's getting hit from the right
                {
                    TakeDamage(1, -50, 200);
                }
                else
                {
                    TakeDamage(1, 50, 200);
                }
                GetComponent<playerScript>().LoseControl(0.7f);
            }
        }
        if (other.CompareTag("Bird"))
        {
            if (TakingDamage)
            {
                if (transform.position.x < other.transform.position.x)//he's getting hit from the right
                {
                    TakeDamage(1, -100, 200);
                }
                else
                {
                    TakeDamage(1, 100, 200);
                }
                GetComponent<playerScript>().LoseControl(1.0f);
            }
        }
        if (other.CompareTag("Bird"))
        {
            if (TakingDamage)
            {
                if (transform.position.x < other.transform.position.x)//he's getting hit from the right
                {
                    TakeDamage(1, -100, 100);
                }
                else
                {
                    TakeDamage(1, 100, 100);
                }
                GetComponent<playerScript>().LoseControl(1.0f);
            }
        }
        if (other.CompareTag("Chauvanismus Attack Box"))
        {
            if (TakingDamage)
            {
                if (transform.position.x < other.transform.position.x)//he's getting hit from the right
                {
                    TakeDamage(1, -100, 300);
                }
                else
                {
                    TakeDamage(1, 100, 300);
                }
                GetComponent<playerScript>().LoseControl(0.7f);
            }
        }
        if (other.CompareTag("Barrel Explosion"))
        {
            if (TakingDamage)
            {
                if (transform.position.x < other.transform.position.x)//he's getting hit from the right
                {
                    TakeDamage(1, -5000, 500);
                }
                else
                {
                    TakeDamage(1, 5000, 500);
                }
                GetComponent<playerScript>().LoseControl(0.7f);
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
    public void TakeDamage(int damage, float recoilX, float recoilY)//lose the actual health from the health int, and recoidl from the hit
    {
        if(TakingDamage == true)
        {
            //recoil from the hit
            rb.AddForce(recoilX, recoilY, 0);

            //lose health,  become temporarily invincible
            health = health - damage;
            TakingDamage = false;
            Invoke("ActivateDamage", 1.5f);
            Debug.Log("TakeDamage() worked");
        }
        
    }

    public void ActivateDamage()
    {
        TakingDamage = true;
    }
}
