using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Revolver : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
    public int bullets = 6;
    public float reloadTime = 2;
    float timer = 10000000;
    public bool isReloading = false;
    public TextMeshProUGUI bulletText;
    bool zeroBullets = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletText.text = bullets.ToString();
        Debug.Log(bullets);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (bullets >= 1 && !isReloading)
            {
                Instantiate(bulletPrefab, bulletSpawn.transform.position, transform.rotation);
                bullets--;
            }
        }

        if(bullets == 0 && zeroBullets)
        {
            isReloading = true;
            timer = Time.time;
            zeroBullets = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if(bullets <= 5)
            {
                isReloading = true;
                timer = Time.time;
            }
        }

        if (isReloading)
        {
            if((Time.time - timer) > reloadTime)
            {
                bullets = 6;
                isReloading = false;
                timer = 1000000;
            } 
        }
        
    }
}
