using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    Rigidbody rb;
    float speed = 5;
    public GameObject feet;
    public GameObject orientation;
    bool IsGrounded;
    LayerMask groundMask;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        IsGrounded = false;
        groundMask = LayerMask.GetMask("Ground");
    }
    void Update()
    {
        IsGrounded = Physics.CheckSphere(feet.transform.position, 0.1f, groundMask);
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(orientation.transform.forward * speed, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.S)) //gustav was here. Jag har fisit här inne i koden
        {
            rb.AddForce(-orientation.transform.forward * speed, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-orientation.transform.right * speed, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(orientation.transform.right * speed, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.Space) && IsGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(transform.up * speed, ForceMode.Impulse);
        }
    }
}

