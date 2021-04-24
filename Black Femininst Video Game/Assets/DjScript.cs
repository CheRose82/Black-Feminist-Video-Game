using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DjScript : MonoBehaviour
{
    public int level;
    public int levelPart;
    public bool gliding;
    public Animator anim;
    public GameObject part;
    // Start is called before the first frame update
    void Start()
    {
        if(level == 2)
        {
            if(levelPart == 1)
            {
                transform.position = new Vector3(225, 6.6f, 0);
                gliding = true;
                Invoke(nameof(DJDeath), 15);
            }
            if(levelPart == 2)
            {
                transform.position = new Vector3(247.18f, 6.6f, 0);
                Invoke(nameof(DJDeath), 15);
                anim.SetBool("bouncing", false);
            }
            
        }
        Sparkle();
        gliding = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gliding)
        {
            transform.Translate(-.035f, 0, 0);
        }
    }

    public void Sparkle()
    {
        //Instantiate(part, transform.position, Quaternion.identity);
    }

    public void DJDeath()
    {
        Destroy(this.gameObject);
    }

    public void MargLevel2Hmph()
    {

    }
}
