using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudreyLordeForrestScript : MonoBehaviour
{
    public GameObject knowledgePart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GiveKnowledge()
    {
        Instantiate(knowledgePart, transform.position, Quaternion.identity);
    }
}
