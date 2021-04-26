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

        //Invoke(nameof(Die), expireTimer);

        //test speeds
        scrollSpeed = .02f;
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
        //Debug.Break();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, scrollSpeed, 0);

        expireTimer -= Time.deltaTime;
        if(expireTimer < 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
        Debug.Log("pic died");
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
