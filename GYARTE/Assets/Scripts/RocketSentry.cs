using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSentry : MonoBehaviour
{
    public Transform rocketSpawn;
    public GameObject rocketPrefab;
    public float timeBetweenShots = 10;
    float timer;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad - timer > timeBetweenShots)
        {
            Instantiate(rocketPrefab, rocketSpawn.transform.position, transform.rotation);
            timer = Time.timeSinceLevelLoad;
        }

        transform.LookAt(player);
    }
}
