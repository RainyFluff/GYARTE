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
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        currentSpeed = rb.velocity.magnitude;
        currentSpeedInt = Mathf.Abs((int)currentSpeed);
        speedText.text = currentSpeedInt.ToString();
    }
}
