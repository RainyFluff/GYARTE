using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootgun : MonoBehaviour
{
   
    public GameObject gun;
    public GameObject cam;
    RaycastHit target;
   
    [Header("Weapon Stats")]
    public int pelletsPerShot = 9;
    public float range = 100;
    public float fireRate = 0f;
    float nextTimeToFire;
    [SerializeField] float inaccuracyDistance = 5f;


    [Header("Weapon Physics")]
    public Rigidbody rb;
    public float forceRecoil = 10f;
    public float knockbackPower = 5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1/fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        for (int i = 0; i < pelletsPerShot; i++)
        {
            if (Physics.Raycast(cam.transform.position, getShootingDirection(), out target, range))
            {
                print(target.collider);
            }
        }
        knockback();
        if(target.rigidbody != null)
        {
            target.rigidbody.AddForce(getShootingDirection() * knockbackPower, ForceMode.VelocityChange);
        }
    }

    Vector3 getShootingDirection()
    {
        Vector3 targetPos = cam.transform.position + cam.transform.forward * range;
        targetPos = new Vector3(
            targetPos.x + Random.Range(-inaccuracyDistance, inaccuracyDistance),
             targetPos.y + Random.Range(-inaccuracyDistance, inaccuracyDistance),
              targetPos.z + Random.Range(-inaccuracyDistance, inaccuracyDistance)
               );

        Vector3 direction = targetPos - cam.transform.position;
        return direction.normalized;
    }

    void knockback()
    {
        rb.AddForce(-getShootingDirection() * forceRecoil, ForceMode.Impulse);
    }
}
