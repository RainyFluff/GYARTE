using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("General")]
    public Rigidbody rb;
    public float Speed = 10f;
    public float jumpForce = 10f;
    public GameObject cam;
    public float sens = 10;
    //public GameObject orientation;
    bool IsGrounded = false;
    public GameObject feet;
    public GameObject orientation;
    LayerMask groundmask;
    public Vector3 direction = Vector3.right;

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
            rb.AddForce(orientation.transform.right * -4);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(orientation.transform.right * 4);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(orientation.transform.forward * 4);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(orientation.transform.forward * -4);
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }
}
