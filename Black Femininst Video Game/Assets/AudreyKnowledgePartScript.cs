using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudreyKnowledgePartScript : MonoBehaviour
{
    public ParticleSystem part;
    public GameObject audreyHead;
    // Start is called before the first frame update
    void Start()
    {
        audreyHead = GameObject.Find("Audrey Lorde Head(Clone)");
        part = this.gameObject.GetComponent<ParticleSystem>();
        transform.localEulerAngles = new Vector3(-90, -90, 0);
        Invoke("Kill", 8f);
    }

    public void Kill()
    {
        part.enableEmission = false;
        audreyHead.GetComponent<AudreyLordeForrestScript>().DisperseAudrey();
    }

    
}
