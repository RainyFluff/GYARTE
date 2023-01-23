using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    public GameObject player;
    public float playerScaleX = 1;
    LayerMask wallMask;
    public GameObject orientation;
    //public Camera cam;

    bool isHuggingWall = false;
    public float wallJumpForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        wallMask = LayerMask.GetMask("Wall");
    }

    // Update is called once per frame
    void Update()
    {
        createPhysicSphere();

        if (isHuggingWall)
        {
            controllMovement();
        }
        else
        {
            enableMovement();

        }
    }

    void createPhysicSphere()
    {
        isHuggingWall = Physics.CheckSphere(player.transform.position, playerScaleX, wallMask);
       
    }

    void controllMovement()
    {
        player.GetComponent<Movement>().enabled = false;
        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.useGravity = false;
        
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce((player.transform.up + orientation.transform.forward) * wallJumpForce, ForceMode.Impulse);
            
        }
    }

    void enableMovement()
    {
        player.GetComponent<Movement>().enabled = true;
        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.useGravity = true;
        
    }
}
