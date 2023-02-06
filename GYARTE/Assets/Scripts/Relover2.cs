using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Relover2 : MonoBehaviour
{
    public GameObject cam;
    RaycastHit target;



    [Header("Weapon Stats")]
    public float range = 100;
    public float fireRate = 0f;
    float nextTimeToFire;

    [Header("LineRenderer")]
    public Transform bulletSpawn;
    public LineRenderer lineRenderer;
    float timer;
    public float timeForBulletDissapear = 0.1f;


    [Header("Weapon Physics")]
    public float knockbackPower = 5f;

    public ParticleSystem muzzleFlash;

    public AudioSource shootieSource;
    public AudioClip shootieSound;
    // Start is called before the first frame update
    void Start()
    {
        
        timer = Mathf.Infinity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1 / fireRate;
            Shoot();
            timer = Time.timeSinceLevelLoad;
        }

        if (Time.timeSinceLevelLoad - timer > timeForBulletDissapear)
        {
            lineRenderer.positionCount = 0;
            timer = Mathf.Infinity;
        }
    }

    void Shoot()
    {
        shootieSource.PlayOneShot(shootieSound, 1);
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, bulletSpawn.position);
        muzzleFlash.Play();

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out target, range))
        {
            print(target.collider);
            if (target.transform.gameObject.CompareTag("target"))
            {
                target.transform.gameObject.GetComponent<hp>().health--;
            }
            lineRenderer.SetPosition(1, target.point);
        }
        else
        {
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);

            lineRenderer.SetPosition(1, ray.GetPoint(100));


        }
        if (target.rigidbody != null)
        {
            target.rigidbody.AddForce(cam.transform.forward * knockbackPower, ForceMode.VelocityChange);
        }
    }



    /*Vector3 getShootingDirection()
    {
        Vector3 targetPos = cam.transform.position + cam.transform.forward * range;
        targetPos = new Vector3(
            targetPos.x + Random.Range(-inaccuracyDistance, inaccuracyDistance),
             targetPos.y + Random.Range(-inaccuracyDistance, inaccuracyDistance),
              targetPos.z + Random.Range(-inaccuracyDistance, inaccuracyDistance)
               );

        Vector3 direction = targetPos - cam.transform.position;
        return direction.normalized;
    }*/

    

}
