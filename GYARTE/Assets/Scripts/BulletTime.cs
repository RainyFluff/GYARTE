using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTime : MonoBehaviour
{

    public float timeMultiplier = 0.2f;
    public float normalTimeMultiplier = 1f;
    public GameObject slowMoPostProcess;
    public GameObject normalPostProcess;
    public bool isSlowMo = false;

    private void Start()
    {
        timeNormal();
        slowMoPostProcess.SetActive(false);
        normalPostProcess.SetActive(true);
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse3))
        {
            timeSlowdown();
            slowMoPostProcess.SetActive(true);
            normalPostProcess.SetActive(false);
            isSlowMo = true;
        }
        else
        {
            timeNormal();
            slowMoPostProcess.SetActive(false);
            normalPostProcess.SetActive(true);
            isSlowMo = false;
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