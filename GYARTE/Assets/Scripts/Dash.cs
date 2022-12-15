using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public GameObject player;
    public Rigidbody rb;
    public float dashDuration = 0.1f;
    float dashTime = 10000000;
    float timer = 0;
    public float dashCooldown = 10;
    public Transform orientation;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad - timer > dashCooldown)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                dashTime = Time.timeSinceLevelLoad; 
                playerDash();
                timer = Time.timeSinceLevelLoad;
            }
        }
        
        if(Time.timeSinceLevelLoad - dashTime > dashDuration)
        {
            timer = Time.timeSinceLevelLoad;
            player.GetComponent<Movement>().enabled = true;
            dashTime = 10000000;
        }
    }

    

    void playerDash()
    {
        
        player.GetComponent<Movement>().enabled = false;
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(orientation.right * -force, ForceMode.Impulse);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(orientation.right * force, ForceMode.Impulse);
        }

        else if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(orientation.forward * force, ForceMode.Impulse);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(orientation.forward * -force, ForceMode.Impulse);
        }

        else
        {
            rb.AddForce(orientation.forward * force, ForceMode.Impulse);
        }

    }
}
