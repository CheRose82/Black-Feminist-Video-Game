using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudreyLordeForrestScript : MonoBehaviour
{
    public GameObject knowledgePart;
    public GameObject disperseExplosion;
    // Start is called before the first frame update
    void Start()
    {
        GiveKnowledge();
        //Invoke("StopKnowledge", 8.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GiveKnowledge()
    {
        Instantiate(knowledgePart, transform.position, Quaternion.identity);
        //knowledgePart.transform.localEulerAngles = new Vector3(90, -90, 0);
    }

    public void DisperseAudrey()
    {
        Instantiate(disperseExplosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    //void StopKnowledge()
    //{
    //    knowledgePart.GetComponent<AudreyKnowledgePartScript>().Kill();
    //}
}
