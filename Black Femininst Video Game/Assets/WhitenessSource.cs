using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhitenessSource : MonoBehaviour
{
    public GameObject[] pics;
    public bool whiteVisible;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            PicsOn();
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            PicsOff();
        }
    }

    public void PicsOn()
    {
        whiteVisible = true;
        pics = GameObject.FindGameObjectsWithTag("pic");

        foreach(GameObject p in pics)
        {
            p.GetComponent<ScrollingWhitenessScript>().PicsOn();
        }
    }

    public void PicsOff()
    {
        whiteVisible = false;
        pics = GameObject.FindGameObjectsWithTag("pic");

        foreach (GameObject p in pics)
        {
            p.GetComponent<ScrollingWhitenessScript>().PicsOff();
        }


    }
}
