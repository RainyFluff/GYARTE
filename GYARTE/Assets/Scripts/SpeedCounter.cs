using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedCounter : MonoBehaviour
{
    Rigidbody rb;
    float currentSpeed;
    int currentSpeedInt;
    public TextMeshProUGUI speedText;
    float timer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = Time.unscaledTime;
    }

   
    void Update()
    {
        if(Time.unscaledTime - timer > 0.2f)
        {
            currentSpeed = rb.velocity.magnitude;
            currentSpeedInt = Mathf.Abs((int)currentSpeed);
            speedText.text = currentSpeedInt.ToString();
            speedText.text = speedText.text + "m/s";
            timer = Time.unscaledTime;
        }
        
        
    }
}
