using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Shootgun : MonoBehaviour
{
   
    public GameObject gun;
    public GameObject cam;
    RaycastHit target;
    Animator animator;

   
    [Header("Weapon Stats")]
    public int pelletsPerShot = 9;
    public float range = 100;
    public float fireRate = 0f;
    float nextTimeToFire;
    [SerializeField] float inaccuracyDistance = 5f;

    [Header("LineRenderer")]
    public Transform bulletSpawn;
    public LineRenderer lineRenderer;
    public LineRenderer lineRenderer2;
    public LineRenderer lineRenderer3;
    public LineRenderer lineRenderer4;
    public LineRenderer lineRenderer5;
    public LineRenderer lineRenderer6;
    public LineRenderer lineRenderer7;
    public LineRenderer lineRenderer8;
    public LineRenderer lineRenderer9;
    float timer;
    public float timeForBulletDissapear = 0.1f;

    [Header("Secondary Fire")]
    public GameObject bulletPrefab;
    public Transform bulletSpawn1;
    public Transform bulletSpawn2;


    [Header("Weapon Physics")]
    public Rigidbody rb;
    public float forceRecoil = 10f;
    public float knockbackPower = 5f;

    GameObject hit;

    public ParticleSystem muzzleFlash;
    public ParticleSystem smokeFlash;

    public AudioSource shootieSource;
    public AudioClip shootieSound;
    public AudioSource altFireShootieSource;
    public AudioClip altFireShootieSound;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        timer = Mathf.Infinity;
        animator.SetBool("Shot", false);
        animator.SetBool("ShotAlt", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextTimeToFire)
        {  
            nextTimeToFire = Time.time + 1/fireRate;
            Shoot();
            timer = Time.timeSinceLevelLoad;
            animator.SetBool("Shot", true);
        }

        else if (Input.GetKeyDown(KeyCode.Mouse1) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1 / fireRate;
            Shoot2();
            animator.SetBool("ShotAlt", true);
        }

        if(Time.timeSinceLevelLoad - timer > timeForBulletDissapear)
        {
            lineRenderer.positionCount = 0;
            lineRenderer2.positionCount = 0;
            lineRenderer3.positionCount = 0;
            lineRenderer4.positionCount = 0;
            lineRenderer5.positionCount = 0;
            lineRenderer6.positionCount = 0;
            lineRenderer7.positionCount = 0;
            lineRenderer8.positionCount = 0;
            lineRenderer9.positionCount = 0;
            timer = Mathf.Infinity;
        }

        
    }

    private void LateUpdate()
    {
        if (!Input.GetKeyDown(KeyCode.Mouse0) && Time.time < nextTimeToFire)
        {
            animator.SetBool("Shot", false);
        }

        if (!Input.GetKeyDown(KeyCode.Mouse1) && Time.time < nextTimeToFire)
        {
            animator.SetBool("ShotAlt", false);
        }

    }
    void Shoot2()
    {
        altFireShootieSource.PlayOneShot(altFireShootieSound); 
        smokeFlash.Play();
        Instantiate(bulletPrefab, bulletSpawn1.transform.position, cam.transform.rotation);
        Instantiate(bulletPrefab, bulletSpawn2.transform.position, cam.transform.rotation);
    }

    void Shoot()
    {
        shootieSource.PlayOneShot(shootieSound, 1);
        muzzleFlash.Play();
        lineRenderer.positionCount = 2;
        lineRenderer2.positionCount = 2;
        lineRenderer3.positionCount = 2;
        lineRenderer4.positionCount = 2;
        lineRenderer5.positionCount = 2;
        lineRenderer6.positionCount = 2;
        lineRenderer7.positionCount = 2;
        lineRenderer8.positionCount = 2;
        lineRenderer9.positionCount = 2;
        for (int i = 0; i < pelletsPerShot; i++)
        {
            if(i == 1)
            {
                lineRenderer.SetPosition(0, bulletSpawn.position);
            }

            else if(i == 2)
            {
                lineRenderer2.SetPosition(0, bulletSpawn.position);
            }

            else if (i == 3)
            {
                lineRenderer3.SetPosition(0, bulletSpawn.position);
            }

            else if (i == 4)
            {
                lineRenderer4.SetPosition(0, bulletSpawn.position);
            }

            else if (i == 5)
            {
                lineRenderer5.SetPosition(0, bulletSpawn.position);
            }

            else if (i == 6)
            {
                lineRenderer6.SetPosition(0, bulletSpawn.position);
            }

            else if (i == 7)
            {
                lineRenderer7.SetPosition(0, bulletSpawn.position);
            }

            else if (i == 8)
            {
                lineRenderer8.SetPosition(0, bulletSpawn.position);
            }

            else if (i == 0)
            {
                lineRenderer9.SetPosition(0, bulletSpawn.position);
            }

            if (Physics.Raycast(cam.transform.position, getShootingDirection(), out target, range))
            {
                print(target.collider);
                if (i == 1)
                {
                    lineRenderer.SetPosition(1, target.point);
                }

                else if (i == 2)
                {
                    lineRenderer2.SetPosition(1, target.point);
                }

                else if (i == 3)
                {
                    lineRenderer3.SetPosition(1, target.point);
                }

                else if (i == 4)
                {
                    lineRenderer4.SetPosition(1, target.point);
                }

                else if (i == 5)
                {
                    lineRenderer5.SetPosition(1, target.point);
                }

                else if (i == 6)
                {
                    lineRenderer6.SetPosition(1, target.point);
                }

                else if (i == 7)
                {
                    lineRenderer7.SetPosition(1, target.point);
                }

                else if (i == 8)
                {
                    lineRenderer8.SetPosition(1, target.point);
                }

                else if (i == 0)
                {
                    lineRenderer9.SetPosition(1, target.point);
                }
                
                if (target.transform.gameObject.CompareTag("target"))
                {
                    target.transform.gameObject.GetComponent<hp>().health--;
                }
            }
            else 
            {
                Ray ray = new Ray(cam.transform.position, getShootingDirection());

                if (i == 1)
                {
                    lineRenderer.SetPosition(1, ray.GetPoint(100));
                }

                else if (i == 2)
                {
                    lineRenderer2.SetPosition(1, ray.GetPoint(100));
                }

                else if (i == 3)
                {
                    lineRenderer3.SetPosition(1, ray.GetPoint(100));
                }

                else if (i == 4)
                {
                    lineRenderer4.SetPosition(1, ray.GetPoint(100));
                }

                else if (i == 5)
                {
                    lineRenderer5.SetPosition(1, ray.GetPoint(100));
                }

                else if (i == 6)
                {
                    lineRenderer6.SetPosition(1, ray.GetPoint(100));
                }

                else if (i == 7)
                {
                    lineRenderer7.SetPosition(1, ray.GetPoint(100));
                }

                else if (i == 8)
                {
                    lineRenderer8.SetPosition(1, ray.GetPoint(100));
                }

                else if (i == 0)
                {
                    lineRenderer9.SetPosition(1, ray.GetPoint(100));
                }
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
