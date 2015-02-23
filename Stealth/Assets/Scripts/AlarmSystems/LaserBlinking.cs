using UnityEngine;
using System.Collections;

public class LaserBlinking : MonoBehaviour {

    public float onTime = 5.0f;
    public float offTime  = 5.0f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (renderer.enabled)
        {
            if (timer >= onTime)
            {
                SwitchBeam();
            }
        }
        else 
        {
            if (timer >= offTime)
            {
                SwitchBeam();
            }
        }
    }

    void SwitchBeam() 
    {
        timer = 0.0f;
        renderer.enabled = !renderer.enabled;
        light.enabled = !light.enabled;
        audio.enabled = !audio.enabled;
    }
}
