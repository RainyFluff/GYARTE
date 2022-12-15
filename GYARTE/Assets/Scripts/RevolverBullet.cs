using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverBullet : MonoBehaviour
{
    public Rigidbody rb;
    public Transform cam;
    public GameObject player;
    public float shootForce = 20;
    public float timeToDespawn = 3;
    public float slowForceMultiplier = 1;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        if (player.GetComponent<BulletTime>().isSlowMo == true)
        {
            slowForceMultiplier = 5;
        }
        rb.AddForce(cam.transform.forward * shootForce * slowForceMultiplier);
        timer = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad - timer > timeToDespawn)
        {
            if(this.name == "Bullet(Clone)")
            {
                Destroy(this.gameObject);
            }
        }
    }

    
}
