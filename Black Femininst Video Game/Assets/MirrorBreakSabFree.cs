﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorBreakSabFree : MonoBehaviour
{
    public GameObject glassParticles;
    public GameObject MirrorRain;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void CrackMirror()
    {
        Instantiate(glassParticles, transform.position, Quaternion.identity);
        MirrorRain.GetComponent<GlassRainScript>().RainGlass();
        Destroy(this.gameObject);
    }
}
