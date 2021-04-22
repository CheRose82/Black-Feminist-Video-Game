using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MargLevel2Ending : MonoBehaviour
{
    public GameObject DBp52;
    public GameObject hammer;
    public GameObject poof;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke(nameof(MargAppear), 3);
        Invoke(nameof(StartDialogue), 4);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MargAppear()
    {
        GetComponent<MeshRenderer>().enabled = true;
        POOF();
    }

    public void StartDialogue()
    {
        Instantiate(DBp52, transform.position + new Vector3(0, -100, 0), Quaternion.identity);
    }

    public void Hammer()
    {
        Instantiate(hammer, transform.position + new Vector3(0, 50, 0), Quaternion.identity);
    }

    public void POOF()
    {
        Instantiate(poof, transform.position, Quaternion.identity);
        //play sound
    }
}
