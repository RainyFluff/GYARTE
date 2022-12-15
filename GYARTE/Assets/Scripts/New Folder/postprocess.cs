using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class postprocess : MonoBehaviour
{

    public Volume vol;
     LensDistortion lens;
    // Start is called before the first frame update
    void Start()
    {
        lens = vol.GetComponent<LensDistortion>();
        lens.intensity.overrideState = true;
    }

    // Update is called once per frame
    void Update()
    {
        lens.intensity.Override(1);
    }
}
