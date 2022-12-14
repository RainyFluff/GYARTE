using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("General")]
    public Rigidbody rb;
    public float Speed = 10f;
    public float jumpForce = 10f;
    public Camera cam;
    public float sens = 10;
    
    void Start()
    {
         
    }

    
    void Update()
    {
        Moving();

        if (Input.GetAxis("Mouse X") != 0)
        {
            //cam.transform.rotation = Q(0, Input.GetAxis("Mouse X"), 0);
            //FIXA
        }
    }


    void Moving()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-Speed, rb.velocity.y, rb.velocity.z);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(Speed, rb.velocity.y, rb.velocity.z);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, Speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -Speed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }
}
