using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeColScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyHitBox", 0.5f);
    }

    public void DestroyHitBox()
    {
        Destroy(this.gameObject);
    }
}
