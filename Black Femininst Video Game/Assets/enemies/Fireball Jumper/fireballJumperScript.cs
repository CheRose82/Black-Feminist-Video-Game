using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballJumperScript : MonoBehaviour
{
    public GameObject fireballTriggerPrefab;
    public GameObject fbt;
    public GameObject proj;
    public GameObject splash;
    public bool activated = false;
    public float timeBetweenFireballs;
    public Vector3 fireballAdj;
    // Start is called before the first frame update
    void Start()
    {
        fbt = Instantiate(fireballTriggerPrefab, transform.position, transform.rotation);
        fbt.GetComponent<fireballJumperTriggerScript>().fireballJumper = this.gameObject;
        fireballAdj = new Vector3(0, 1, 0);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("JumpFireball"))
        {
            WaitAndShoot();
            Vector3 pos = new Vector3(0, .7f, 0);
            Instantiate(splash, transform.position + pos, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }

    private void WaitAndShoot()
    {
        Invoke("ShootFireball", timeBetweenFireballs);
    }
    public void ShootFireball()
    {
        if (activated)
        {
            Instantiate(proj, transform.position + fireballAdj, transform.rotation);
            //Debug.Log("the fireball should be shot from the fireball jumper");
        }
        
    }


}
