using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MargPauseScript : MonoBehaviour
{
    public Text thisText;
    public Image thisImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(thisText.enabled == true)
            {
                thisText.enabled = false;
                thisImage.enabled = false;
            }
            else
            {
                thisText.enabled = true;
                thisImage.enabled = true;
            }
        }
    }
}
