using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTextBlinkScript : MonoBehaviour
{
    public Text thistext;
    public bool TextEnabled;
    // Start is called before the first frame update
    void Start()
    {
        TextEnabled = true;
        Blink();

    }


    public void Blink()
    {
        if(TextEnabled == true)
        {
            thistext.enabled = false;
            TextEnabled = false;
        }
        else
        {
            thistext.enabled = true;
            TextEnabled = true;
        }
        Cycle();
    }

    public void Cycle()
    {
        Invoke("Blink", 1);
    }
}
