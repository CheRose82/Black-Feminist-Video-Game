using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorControllerScript : MonoBehaviour
{
    public GameObject[] mirrors;
    public GameObject[] mirrorPlane;
    public GameObject[] nicoleAnm;
    public GameObject[] closingMirrors;
    public GameObject[] cmPlane;
    public GameObject[] cmAnim;

    public GameObject blackoutBox;
    public GameObject centralMirror;
    public GameObject centralAnim;
    public GameObject centralPlane;

    public GameObject exitDoor;
    public GameObject part;

    public Animator anim;
    public float destroyTime;
    
    // Start is called before the first frame update
    void Start()
    {
        mirrors = GameObject.FindGameObjectsWithTag("Mirror");
        closingMirrors = GameObject.FindGameObjectsWithTag("Closing Mirrors");
        centralMirror = GameObject.Find("Central Mirror");
        blackoutBox = GameObject.Find("Blackout");
        cmPlane = GameObject.FindGameObjectsWithTag("NicolePlane");
        cmAnim = GameObject.FindGameObjectsWithTag("NicoleAnim");

        //foreach (GameObject m in mirrors)
        //{
        //    m.GetComponentInChildren<MeshRenderer>().enabled = false;
        //}
            

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            DanceNicole();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            HandNicole();
        }

        //end level
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            DestroyCentral();
        }
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
        foreach (GameObject cmp in cmPlane)
        {
            cmp.GetComponent<MeshRenderer>().enabled = false;
        }
        foreach(GameObject cma in cmAnim)
        {
            cma.GetComponent<SpriteRenderer>().enabled = false;
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
        foreach (GameObject cmp in cmPlane)
        {
            cmp.GetComponent<MeshRenderer>().enabled = true;
        }
        foreach (GameObject cma in cmAnim)
        {
            cma.GetComponent<SpriteRenderer>().enabled = true;
        }

        blackoutBox.GetComponent<blackoutBoxScript>().UnBlackout();
    }

    public void CentralMirrorOn()
    {
        centralMirror.GetComponentInChildren<MeshRenderer>().enabled = true;
        centralAnim.GetComponent<SpriteRenderer>().enabled = true;
        centralPlane.GetComponent<MeshRenderer>().enabled = true;
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

    public void DanceNicole()
    {
        foreach (GameObject cma in cmAnim)
        {
            cma.GetComponent<Animator>().SetTrigger("danceTrigger");
        }
    }

    public void HandNicole()
    {
        foreach (GameObject cma in cmAnim)
        {
            cma.GetComponent<Animator>().SetTrigger("handTrigger");
        }
    }

    public void DestroyCentral()
    {
        Instantiate(exitDoor, new Vector3(303.56f, 4.41f, 0.69f), Quaternion.identity);
        Instantiate(part, centralMirror.transform.position, Quaternion.identity);
        Destroy(centralMirror);
    }


}
