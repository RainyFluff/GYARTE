using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTime : MonoBehaviour
{

    public float timeMultiplier = 0.2f;
    public float normalTimeMultiplier = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse3))
        {
            timeSlowdown();
        }
        else
        {
            timeNormal();
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