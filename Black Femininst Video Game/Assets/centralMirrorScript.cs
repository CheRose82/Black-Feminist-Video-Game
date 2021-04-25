using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centralMirrorScript : MonoBehaviour
{
    public GameObject part;
    public GameObject dbNopeThat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            MirrorBreakWrong();
        }
    }

    public void MirrorBreakWrong()
    {
        Instantiate(part, transform.position, Quaternion.identity);
        Instantiate(dbNopeThat, transform.position, Quaternion.identity);
    }
}
