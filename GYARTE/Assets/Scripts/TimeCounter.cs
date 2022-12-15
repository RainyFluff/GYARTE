using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public float countedTime;
    public float countedTimeInScene;
    public int printedTime;
    float timeBeforeScene;
    
    // Start is called before the first frame update
    void Start()
    {
        timeBeforeScene = Time.unscaledTime - Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        countedTimeInScene = countedTime - timeBeforeScene;
        int printedTime = (int)countedTimeInScene;


        countedTime = Time.unscaledTime;
        
        
        counterText.text = printedTime.ToString();
    }




    
}
