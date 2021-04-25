using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MargLevel4Script : MonoBehaviour
{
    public GameObject dbFinal;
    public GameObject margAnim;
    public GameObject chauv;
    public Animator anim;
    public int level;
    public int levelPart;
    public bool leaving;
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        chauv = GameObject.Find("Chauvanismus");
        Destroy(chauv);
        if(level == 4)
        {
            Instantiate(dbFinal, transform.position + new Vector3(-1, -100, 0), Quaternion.identity);
            transform.position = new Vector3(156, 8, 0);
        }

        if(level == 2)
        {
            if (levelPart == 1)
            {
                transform.position = new Vector3(242.27f, 7.41f, 0);
            }

            if(levelPart == 2)
            {
                //redundant
                //transform.position = transform.position;
                Invoke(nameof(PoofIn), 3);
            }
            
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
        //margAnim.GetComponent<SpriteRenderer>().enabled = true;
        anim.SetBool("doingNothing", false);
        anim.SetTrigger("poofIn");
        Invoke(nameof(Appear), 0.5f);
    }

    public void Level2Leave()
    {
        leaving = true;
    }

    public void Appear()
    {
        margAnim.GetComponent<SpriteRenderer>().enabled = true;
    }

    
}
