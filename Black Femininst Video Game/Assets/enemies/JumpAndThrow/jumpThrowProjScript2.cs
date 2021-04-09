using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpThrowProjScript2 : MonoBehaviour
{
    Rigidbody rb;
    public float speed;

    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 7.50f;
        target = GameObject.Find("Player").transform;

        // Rotate the camera every frame so it keeps looking at the target
        transform.LookAt(target);
        Invoke("Destroy", 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed;
    }
    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}
