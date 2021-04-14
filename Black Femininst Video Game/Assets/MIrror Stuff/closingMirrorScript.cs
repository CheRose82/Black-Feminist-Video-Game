using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closingMirrorScript : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed;
    public bool activated;
    public GameObject sparkle;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            
        }
    }

    public void CloseMirror()
    {
        activated = true;
    }

    public void StartDestroy()
    {
        Invoke(nameof(SparkleDestroy), Random.Range(0f, .1f));
    }
    public void SparkleDestroy()
    {
        Instantiate(sparkle, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
