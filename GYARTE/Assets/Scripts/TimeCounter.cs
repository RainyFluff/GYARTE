using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public float countedTime;
    public int printedTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int printedTime = (int)countedTime;

        countedTime = Time.timeSinceLevelLoad;
        counterText.text = printedTime.ToString();
    }




    
}
