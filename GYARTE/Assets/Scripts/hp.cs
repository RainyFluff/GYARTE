using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp : MonoBehaviour
{
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "target";
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
