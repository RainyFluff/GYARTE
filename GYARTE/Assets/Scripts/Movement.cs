using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("General")]
    public Rigidbody rb;
    float speed = 0.2f;
    float airSpeed = 0.1f;
    float normalSpeed = 0.15f;
    float jumpForce = 6f;
    float frictionForce = 1f;
    //public GameObject cam;
    float sens = 10;
    //public GameObject orientation;
    bool IsGrounded = false;
    public GameObject feet;
    public GameObject orientation;
    LayerMask groundmask;
    public Vector3 direction = Vector3.right;
    float maxSpeed;
    float maxSpeedOne = 10;
    float maxSpeedTwo = 15;
    //public float airMaxSpeed = 10;
    bool isMoving;
    float airMaxSpeedDouble;
    int jumpsleft;
    AudioSource windSource;
    AudioClip windClip;

    public GameObject stepHolder;
    AudioSource stepSource;
    AudioClip stepClip;

    void Start()
    {
        groundmask = LayerMask.GetMask("Ground");
        rb = GetComponent<Rigidbody>();
        windSource = GetComponent<AudioSource>();
        windClip = windSource.clip;
        stepSource = stepHolder.GetComponent<AudioSource>();
        stepClip = stepSource.clip;
    }

    
    void Update()
    {
        Moving();

        //Debug.Log(IsGrounded);
        

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
            stepSource.Stop();
            if (!windSource.isPlaying)
            {
                windSource.Play();
            }
            if (jumpsleft >= 1)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.velocity = new Vector3(0, 0, 0);
                    rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
                    rb.AddForce(orientation.transform.forward * jumpForce, ForceMode.Impulse);
                    jumpsleft--;
                }
            }
            speed = airSpeed;

            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(orientation.transform.right * -speed * 15, ForceMode.Acceleration);
            }

            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(orientation.transform.right * speed * 15, ForceMode.Acceleration);
            }

            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(orientation.transform.forward * speed * 15, ForceMode.Acceleration);
            }

            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(orientation.transform.forward * -speed * 15, ForceMode.Acceleration);
            }
            

        }


        if (IsGrounded)
        {
            if((rb.velocity.x +rb.velocity.z) > 2)
            {
                if (!stepSource.isPlaying)
                {
                    stepSource.Play();
                }
            }
            else
            {
                stepSource.Stop();
            }
            windSource.Stop();
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
            rb.AddForce(rb.velocity * -frictionForce);
            if (isMoving)
            {
                
                
            }
            else
            {
                //rb.AddForce(rb.velocity * -frictionForce * 4);
            }
        }
        else
        {
           
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
