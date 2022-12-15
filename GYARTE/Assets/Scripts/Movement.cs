using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("General")]
    public Rigidbody rb;
    public float speed = 0.2f;
    public float airSpeed = 0.05f;
    public float normalSpeed = 0.2f;
    public float jumpForce = 10f;
    public GameObject cam;
    public float sens = 10;
    //public GameObject orientation;
    bool IsGrounded = false;
    public GameObject feet;
    public GameObject orientation;
    LayerMask groundmask;
    public Vector3 direction = Vector3.right;
    public float maxSpeed = 5;

    void Start()
    {
        groundmask = LayerMask.GetMask("Ground");
        rb = GetComponent<Rigidbody>();
        
    }

    
    void Update()
    {
        Moving();

        
        IsGrounded = Physics.CheckSphere(feet.transform.position, 0.1f, groundmask);

        //float playerTurn = cam.GetComponent<MouseLook>().turn.x;
        //float playerSensitivity = cam.GetComponent<MouseLook>().sensitivity;

        //transform.localRotation = Quaternion.Euler(0, playerTurn * playerSensitivity * 3, 0);

        
        
    }

    private void FixedUpdate()
    {
        
    }


    void Moving()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(orientation.transform.right * -speed, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(orientation.transform.right * speed, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(orientation.transform.forward * speed, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(orientation.transform.forward * -speed, ForceMode.VelocityChange);
        }

        if (IsGrounded)
        {
            speed = normalSpeed;
            if (Input.GetKey(KeyCode.Space))
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            }

            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            }
        }
        else
        {
            speed = airSpeed;
        }

        

        
        




    }
}
