using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverBullet : MonoBehaviour
{
    Rigidbody rb;
    public Transform orientation;
    public float shootForce = 20;

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(orientation.transform.forward * shootForce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
