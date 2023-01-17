using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 5;
    public float rotateSpeed = 5;
    public Transform player;
    public float rocketLifeTime = 5;
    float timer;
    public Rigidbody rb;
    public float maxSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(player);

        //transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (Time.timeSinceLevelLoad - timer > rocketLifeTime && this.gameObject.name != "Rocket")
        {
            Destroy(this.gameObject);
        }
        Vector3 playerDirection = player.position - transform.position;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, playerDirection, rotateSpeed * Time.deltaTime, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);

        rb.AddForce(transform.forward * 5, ForceMode.Acceleration);

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.name != "Rocket")
        {
            Destroy(this.gameObject);
        }
    }
}
