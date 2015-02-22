using UnityEngine;
using System.Collections;

public class AlarmLight : MonoBehaviour {
    public float fadeSpeed = 2.0f;
    public float highIntensity = 2.0f;
    public float lowIntensity = .5f;
    public float changeMargin = 0.2f;
    public bool alarmOn;

    float targetIntensity;
	// Use this for initialization
    void Awake() 
    {
        light.intensity = 0f;
        targetIntensity = highIntensity;
    }
    void Start()
    {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (alarmOn)
        {
            light.intensity = Mathf.Lerp(light.intensity, targetIntensity, fadeSpeed * Time.deltaTime);
            CheckTargetIntensity();
        }
        else
        {
            light.intensity = Mathf.Lerp(light.intensity, 0, fadeSpeed * Time.deltaTime);
        }
	}

    void CheckTargetIntensity()
    {
        if (Mathf.Abs(targetIntensity - light.intensity) < changeMargin)
        {
            if (targetIntensity == highIntensity)
            {
                targetIntensity = lowIntensity;
            }
            else 
            {
                targetIntensity = highIntensity;
            }
        }
    }
}
