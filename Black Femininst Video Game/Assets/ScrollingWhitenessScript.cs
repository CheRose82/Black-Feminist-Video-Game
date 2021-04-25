using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingWhitenessScript : MonoBehaviour
{
    public float scrollSpeed;
    public float expireTimer;
    SpriteRenderer sr;
    public GameObject source;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();

        Invoke(nameof(Die), expireTimer);

        //test speeds
        scrollSpeed = .1f;
        expireTimer = 10;

        source = GameObject.Find("Whiteness Image Source");

        if(source.GetComponent<WhitenessSource>().whiteVisible == true)
        {
            PicsOn();
        }
        else
        {
            PicsOff();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, scrollSpeed, 0);
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

    public void PicsOff()
    {
        sr.enabled = false;
    }

    public void PicsOn()
    {
        sr.enabled = true;
    }

}
