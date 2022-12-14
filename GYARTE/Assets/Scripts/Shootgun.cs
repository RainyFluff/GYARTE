using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootgun : MonoBehaviour
{
    public GameObject gun;
    public GameObject cam;
    public int pelletsPerShot = 9;
    RaycastHit target;
    public float range = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        for (int i = 0; i < pelletsPerShot; i++)
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out target, range))
            {
                print(target.collider);
            }
        }
        
    }
}
