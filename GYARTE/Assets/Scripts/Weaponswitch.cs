using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weaponswitch : MonoBehaviour
{
    public GameObject Revolver;
    public GameObject Shotgun;
    public GameObject Katana;
    public TextMeshProUGUI bulletText;

    // Start is called before the first frame update
    void Start()
    {
        Shotgun.SetActive(false);
        Revolver.SetActive(false);
        bulletText.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Katana.SetActive(true);
            Shotgun.SetActive(false);
            Revolver.SetActive(false);
            bulletText.gameObject.SetActive(false);
            Revolver.GetComponent<Revolver>().isReloading = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Katana.SetActive(false);
            Shotgun.SetActive(true);
            Revolver.SetActive(false);
            bulletText.gameObject.SetActive(false);
            Revolver.GetComponent<Revolver>().isReloading = false;

        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Katana.SetActive(false);
            Shotgun.SetActive(false);
            Revolver.SetActive(true);
            bulletText.gameObject.SetActive(true);
        }

    }
}
