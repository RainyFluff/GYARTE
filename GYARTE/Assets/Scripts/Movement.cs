using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("General")]
    public Rigidbody rb;
    float speed = 0.2f;
    public float airSpeed = 0.05f;
    public float normalSpeed = 0.2f;
    public float jumpForce = 10f;
    public float frictionForce = 10f;
    //public GameObject cam;
    public float sens = 10;
    //public GameObject orientation;
    bool IsGrounded = false;
    public GameObject feet;
    public GameObject orientation;
    LayerMask groundmask;
    public Vector3 direction = Vector3.right;
    float maxSpeed;
    public float maxSpeedOne = 3;
    public float maxSpeedTwo = 5;
    public float airMaxSpeed = 10;
    bool isMoving;
    float airMaxSpeedDouble;
    int jumpsleft;

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
        if (!IsGrounded)
        {
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(orientation.transform.right * -speed, ForceMode.Acceleration);
            }

            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(orientation.transform.right * speed, ForceMode.Acceleration);
            }

            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(orientation.transform.forward * speed, ForceMode.Acceleration);
            }

            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(orientation.transform.forward * -speed, ForceMode.Acceleration);
            }

        }


        if (IsGrounded)
        {
            jumpsleft = 2;
            speed = normalSpeed;
            if (Input.GetKey(KeyCode.Space))
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
                jumpsleft--;
            }

            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                isMoving = true;
            }

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

            if (isMoving)
            {
                rb.AddForce(rb.velocity * -frictionForce);
            }
            else
            {
                rb.AddForce(rb.velocity * -frictionForce * 4);
            }




        }
        else
        {
            if (jumpsleft >= 1)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.velocity = new Vector3(0, 0, 0);
                    rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
                    jumpsleft --;
                }
            }
            speed = airSpeed;
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, airMaxSpeed);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed *= 2;
            maxSpeed = maxSpeedTwo;
        }

        else
        {
            speed = normalSpeed;
            maxSpeed = maxSpeedOne;
        }

        

        
        




    }
}
