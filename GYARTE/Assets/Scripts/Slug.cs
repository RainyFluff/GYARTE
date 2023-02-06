using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slug : MonoBehaviour
{
    Rigidbody rb;
    public float explosionForce = 20;
    public float explosionRadius = 5;
    public float force = 15;
    GameObject cam;
    private Collider[] hitColliders;
    public ParticleSystem explosionParticle;

    AudioSource explosiSource;
    AudioClip explosiSound;
    GameObject soundHolder;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("PlayerCamera");
        rb = GetComponent<Rigidbody>();
        transform.Rotate(90, 0, 0);
        rb.AddForce(cam.transform.forward * force, ForceMode.Impulse);
        soundHolder = GameObject.Find("soundHolder");
        explosiSource = soundHolder.GetComponent<AudioSource>();
        explosiSound = explosiSource.clip;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (this.name != "Slug")
        {
            explosiSource.PlayOneShot(explosiSound);
            Explosion(transform.position);

            Destroy(this.gameObject);
        }
    }

    void Explosion(Vector3 explosionPoint)
    {
        hitColliders = Physics.OverlapSphere(explosionPoint, explosionRadius);
        
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
        foreach (Collider hitCol in hitColliders)
        {
            if (hitCol.GetComponent<Rigidbody>() != null)
            {
                hitCol.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, explosionPoint, explosionRadius, 1, ForceMode.Impulse);

            }
        }
    }
}