using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSentry : MonoBehaviour
{
    public Transform rocketSpawn;
    public GameObject rocketPrefab;
    public float timeBetweenShots = 10;
    float timer = 0;
    public GameObject player;
    CapsuleCollider playerCollider;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        playerCollider = player.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hit.collider);
        if (Time.timeSinceLevelLoad - timer > timeBetweenShots)
        {
            if (Physics.Raycast(rocketSpawn.position, rocketSpawn.transform.forward, out hit, 100)) 
            {                
                if(hit.collider == playerCollider)
                {
                    Instantiate(rocketPrefab, rocketSpawn.transform.position, transform.rotation);
                    timer = Time.timeSinceLevelLoad;
                }
            }
        }
        transform.LookAt(player.transform.position);
        rocketSpawn.transform.LookAt(player.transform.position);
    }
}
