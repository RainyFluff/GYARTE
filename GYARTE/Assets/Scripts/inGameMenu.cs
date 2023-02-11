using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameMenu : MonoBehaviour
{
    public Canvas canvas;
    public GameObject postProcessing;
    public GameObject normalPostProcessing;
    public AudioListener listener;
    bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (active == false)
            {
                canvas.gameObject.SetActive(true);
                active = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                postProcessing.SetActive(true);
                normalPostProcessing.SetActive(false);
                listener.enabled = false;
            }
            else
            {
                removeMenu();
                active = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                postProcessing.SetActive(false);
                normalPostProcessing.SetActive(true);
                listener.enabled = true;
            }
        }
        
    }
    public void removeMenu()
    {
        canvas.gameObject.SetActive(false);
    }
}
