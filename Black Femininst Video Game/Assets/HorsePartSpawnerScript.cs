using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorsePartSpawnerScript : MonoBehaviour
{
    public GameObject horsePart;
    public float spawnRate;
    public float spawnRateReset;
    public GameObject uniPos;
    private float xPos;
    private float yPos;
    private float zPos;
    private float unicornSpawn;
    public GameObject unicornExpl;
    public GameObject unicorn;
    private bool spawnedExpl;
    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 0.5f;
        spawnRateReset = 0.5f;
        uniPos = GameObject.Find("UniPos");
        xPos = uniPos.transform.position.x;
        yPos = uniPos.transform.position.y;
        zPos = uniPos.transform.position.z;
        unicornSpawn = 70f;
        unicorn = GameObject.Find("Black Unicorn");
    }

    // Update is called once per frame
    void Update()
    {

        //countdown till we spawn the horse
        unicornSpawn -= Time.deltaTime;
        if(unicornSpawn < 0.5f)
        {
            Instantiate(unicornExpl, uniPos.transform.position, Quaternion.identity);
            unicorn.transform.position = uniPos.transform.position;
            Destroy(this.gameObject);
        }

        if(unicornSpawn < 0)
        {
            unicorn.transform.position = uniPos.transform.position;
            Destroy(this.gameObject);
        }



        transform.Rotate(10, 11, 10);
        transform.position = new Vector3(xPos + Random.Range(-10, 10), yPos + Random.Range(-10, 10), zPos + Random.Range(-10, 10));
        spawnRate -= Time.deltaTime;
        if(spawnRate < 0)
        {
            Instantiate(horsePart, transform.position, transform.rotation);
            spawnRate = spawnRateReset;
            spawnRateReset = spawnRateReset - .01f;
        }
    }
}
