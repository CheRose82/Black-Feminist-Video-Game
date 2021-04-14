using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassRainStopScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(Stop), 2);
    }

    public void Stop()
    {
        Destroy(this.gameObject);
    }
}
