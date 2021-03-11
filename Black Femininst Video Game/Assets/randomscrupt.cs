using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomscrupt : MonoBehaviour
{
    public GameObject thing1;
    public GameObject thing2;
    public GameObject thing3;
    public int randomnumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        randomnumber = Random.Range(0, 2);
        Vector3 pos = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100));
        if(randomnumber == 0)
        {
            Instantiate(thing1, pos, transform.rotation);
        }
    }
}
