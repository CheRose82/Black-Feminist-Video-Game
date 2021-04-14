using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassRainScript : MonoBehaviour
{
    public GameObject glassParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RainGlass()
    {
        Invoke(nameof(GlassRaining),2f);
    }

    public void GlassRaining()
    {
        Instantiate(glassParticles, transform.position, Quaternion.identity);
    }
}
