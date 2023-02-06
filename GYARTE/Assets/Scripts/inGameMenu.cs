using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameMenu : MonoBehaviour
{
    public Canvas canvas;
    float timeScale;
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
            }
            else
            {
                removeMenu();
                active = false;
                Cursor.visible = false;
            }
        }
        
    }
    public void removeMenu()
    {
        canvas.gameObject.SetActive(false);
    }
}
