using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorHover : MonoBehaviour
{
    public float yMag;
    public float yFreq;
    public float yPos;
    public float yAdj;
    // Start is called before the first frame update
    void Start()
    {
        yAdj = transform.position.y;

        yMag = Random.Range(0.48f, 0.52f);
        yFreq = Random.Range(0.95f, 1.05f);
    }

    // Update is called once per frame
    void Update()
    {
        yPos = Mathf.Sin(yFreq * Time.time) * yMag;
        transform.position = new Vector3(transform.position.x, yPos + yAdj, transform.position.z);
    }
}
