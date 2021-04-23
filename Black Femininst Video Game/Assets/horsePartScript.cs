using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horsePartScript : MonoBehaviour
{
    public GameObject uniPos;
    Rigidbody rb;
    public float speed;
    public float turnSpeed;
    private bool comingBack;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        uniPos = GameObject.Find("UniPos");
        Invoke(nameof(Die), 5);
        Invoke(nameof(ComeBack), 1);
        target = uniPos.transform;
        turnSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDirection = target.position - transform.position;
        float singleStep = turnSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        rb.velocity = transform.forward * speed;

        //if (comingBack == false)
        //{
        //    rb.velocity = transform.forward * speed;
        //}

        //if (comingBack == true)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, uniPos.transform.position, speed * Time.deltaTime);
        //}

        
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
    void ComeBack()
    {

    }
}
