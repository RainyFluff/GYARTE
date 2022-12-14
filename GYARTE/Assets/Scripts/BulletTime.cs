using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTime : MonoBehaviour
{

    public float timeMultiplier = 0.2f;
    public float normalTimeMultiplier = 1f;
    public GameObject slowMoPostProcess;
    public GameObject normalPostProcess;

    private void Start()
    {
        timeNormal();
        //slowMoPostProcess.SetActive(false);
        //normalPostProcess.SetActive(true);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse3))
        {
            timeSlowdown();
            slowMoPostProcess.SetActive(true);
            normalPostProcess.SetActive(false);
        }
        
        if(Input.GetKeyUp(KeyCode.Mouse3))
        {
            timeNormal();
            slowMoPostProcess.SetActive(false);
            normalPostProcess.SetActive(true);
        }
    }

    void timeSlowdown()
    {
        Time.timeScale = timeMultiplier;
        Time.fixedDeltaTime = timeMultiplier * .02f;
    }

    void timeNormal()
    {
        Time.timeScale = normalTimeMultiplier;
        Time.fixedDeltaTime = normalTimeMultiplier * .02f;
    }
}