using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBCollPArtScript : MonoBehaviour
{
    //I'm using a particle effect that I bought from a pack online, it automatically fires over and over again after a sec or two.
    //I this script to invoke a destroy after a certain amount of time.
    public float destroyExplosion;//the amount of time before particle object destroys.

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Death", destroyExplosion);
    }


    void Death()
    {
        Destroy(this.gameObject);
    }
}
