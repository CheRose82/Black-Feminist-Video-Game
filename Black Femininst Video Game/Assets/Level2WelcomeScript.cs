using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2WelcomeScript : MonoBehaviour
{
    public GameObject db;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer< 0)
        {
            Instantiate(db, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
