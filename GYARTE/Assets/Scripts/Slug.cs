using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slug : MonoBehaviour
{
    public Rigidbody rb;
    public float explosionForce = 20;
    public float explosionRadius = 5;
    public float force = 15;
    public Transform cam;
    private Collider[] hitColliders;    
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(90, 0, 0);
        rb.AddForce(cam.forward * force, ForceMode.Impulse);
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
            Explosion(transform.position);
            Destroy(this.gameObject);
        }
    }

    void Explosion(Vector3 explosionPoint)
    {
        hitColliders = Physics.OverlapSphere(explosionPoint, explosionRadius);

        foreach (Collider hitCol in hitColliders)
        {
            if(hitCol.GetComponent<Rigidbody>() != null)
            {
                hitCol.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, explosionPoint, explosionRadius, 1, ForceMode.Impulse);
            }
        }
    }
}
