using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorControllerScript : MonoBehaviour
{
    public GameObject[] mirrors;
    public GameObject[] closingMirrors;
    // Start is called before the first frame update
    void Start()
    {
        mirrors = GameObject.FindGameObjectsWithTag("Mirror");
        closingMirrors = GameObject.FindGameObjectsWithTag("Closing Mirrors");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RaiseMirrors()
    {
        foreach (GameObject m in mirrors)
        {
            m.GetComponent<MirrorScript>().RandomRise();
        }
    }

    public void CloseMirrors()
    {
        foreach (GameObject cm in closingMirrors)
        {
            cm.GetComponent<closingMirrorScript>().CloseMirror();
        }
    }
}
