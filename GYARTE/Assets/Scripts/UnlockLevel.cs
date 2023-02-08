using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLevel : MonoBehaviour
{
    GameObject player;
    public GameObject nextPart;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        nextPart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            nextPart.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
