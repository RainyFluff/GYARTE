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
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("PlayerCamera");
        rb = GetComponent<Rigidbody>();
        transform.Rotate(90, 0, 0);
        rb.AddForce(cam.transform.forward * force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //explosionParticle.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (this.name != "Slug")
        {
            Explosion(transform.position);
            
            Destroy(this.gameObject);
        }
    }

    void Explosion(Vector3 explosionPoint)
    {
        hitColliders = Physics.OverlapSphere(explosionPoint, explosionRadius);
        explosionParticle.Play();
        foreach (Collider hitCol in hitColliders)
        {
            if(hitCol.GetComponent<Rigidbody>() != null)
            {
                hitCol.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, explosionPoint, explosionRadius, 1, ForceMode.Impulse);
                
            }
        }
    }
}
