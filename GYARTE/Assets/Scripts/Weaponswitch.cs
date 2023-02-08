using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weaponswitch : MonoBehaviour
{
    public GameObject Revolver;
    public GameObject Shotgun;
    
    // Start is called before the first frame update
    void Start()
    {
        Shotgun.SetActive(false);
        Revolver.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
            Shotgun.SetActive(false);
            Revolver.SetActive(true);
            
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            
            Shotgun.SetActive(true);
            Revolver.SetActive(false);
            
            

        }

       

    }
}
