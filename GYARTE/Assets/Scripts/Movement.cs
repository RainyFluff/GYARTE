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

    
    bool IsGrounded = false;
    public GameObject feet;
    LayerMask groundmask;
    void Start()
    {
        groundmask = LayerMask.GetMask("Ground");
    }

    
    void Update()
    {
        Moving();
        IsGrounded = Physics.CheckSphere(feet.transform.position, 0.1f, groundmask);
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

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }
}
