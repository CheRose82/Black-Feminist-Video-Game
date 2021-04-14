using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorControllerScript : MonoBehaviour
{
    public GameObject[] mirrors;
    public GameObject[] closingMirrors;

    public GameObject blackoutBox;
    public GameObject centralMirror;
    // Start is called before the first frame update
    void Start()
    {
        mirrors = GameObject.FindGameObjectsWithTag("Mirror");
        closingMirrors = GameObject.FindGameObjectsWithTag("Closing Mirrors");
        centralMirror = GameObject.Find("Central Mirror");
        blackoutBox = GameObject.Find("Blackout");
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

        foreach (GameObject cm in closingMirrors)
        {
            cm.GetComponent<MirrorScript>().RandomRise();
        }
    }

    public void CloseMirrors()
    {
        foreach (GameObject cm in closingMirrors)
        {
            cm.GetComponent<closingMirrorScript>().CloseMirror();
        }
    }

    public void BlackoutMirrors()
    {
        //blackout the background mirrors
        //change this to sprite renderer when you get theh sprites
        foreach (GameObject m in mirrors)
        {
            m.GetComponentInChildren<MeshRenderer>().enabled = false;
        }

        //blackout the closing mirrors
        //change this to sprite renderer when you get theh sprites
        foreach (GameObject cm in closingMirrors)
        {
            cm.GetComponentInChildren<MeshRenderer>().enabled = false;
        }

        //make the central mirror appear a few seconds later
        Invoke(nameof(CentralMirrorOn), 3);
        
    }

    public void UnBlackoutMirrors()
    {
        //UN blackout the background mirrors
        //change this to sprite renderer when you get theh sprites
        foreach (GameObject m in mirrors)
        {
            m.GetComponentInChildren<MeshRenderer>().enabled = true;
        }

        //UN blackout the closing mirrors
        //change this to sprite renderer when you get theh sprites
        foreach (GameObject cm in closingMirrors)
        {
            cm.GetComponentInChildren<MeshRenderer>().enabled = true;
        }

        blackoutBox.GetComponent<blackoutBoxScript>().UnBlackout();
    }

    public void CentralMirrorOn()
    {
        centralMirror.GetComponentInChildren<MeshRenderer>().enabled = true;
        //play cmirror appearing sound effect
    }

    public void DestroyAllMirrors()
    {
        //destroy all the background mirrors
        foreach (GameObject m in mirrors)
        {
            m.GetComponent<MirrorScript>().StartDestroy();
        }

        //destroy all the side mirrors
        foreach (GameObject cm in closingMirrors)
        {
            cm.GetComponent<closingMirrorScript>().StartDestroy();
        }
    }

    
}
