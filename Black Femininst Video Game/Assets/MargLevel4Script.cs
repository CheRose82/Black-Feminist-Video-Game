using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MargLevel4Script : MonoBehaviour
{
    public GameObject dbFinal;
    public GameObject margAnim;
    public Animator anim;
    public int level;
    public bool leaving;
    // Start is called before the first frame update
    void Start()
    {
        if(level == 4)
        {
            Instantiate(dbFinal, transform.position, Quaternion.identity);
        }

        if(level == 2)
        {
            transform.position = new Vector3(242.27f, 7.41f, 0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(leaving == true)
        {
            transform.Translate(0, .5f, 0);
        }
    }

    public void Scoffing()
    {
        anim.SetTrigger("scoffing");
        anim.SetBool("doingNothing", false);
    }

    public void PoofIn()
    {
        margAnim.GetComponent<SpriteRenderer>().enabled = true;
        anim.SetBool("doingNothing", false);
        anim.SetTrigger("poofIn");
    }

    public void Level2Leave()
    {
        leaving = true;
    }

    
}
