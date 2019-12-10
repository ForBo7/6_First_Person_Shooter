using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
	[SerializeField] float lightFade = 0f;
	[SerializeField] float angleFade = 0f;
    [SerializeField] float minimumAngleFade = 0f;

    Light myLight;

    private void Start()
    {
        myLight = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseLightIntensity();
        DecreaseLightAngle();
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        myLight.spotAngle = restoreAngle;
    }

    public void RestoreLightIntensity(float restoreIntensity)
    {
        myLight.intensity = restoreIntensity;
    }

    private void DecreaseLightAngle()
    {
        if (myLight.spotAngle <= minimumAngleFade)
        {
            return;
        }
        else
        {
            myLight.spotAngle -= angleFade * Time.deltaTime;
        }
    }

    private void DecreaseLightIntensity()
    {
        if (myLight.intensity <= 0)
        {
            return;
        }
        else
        {
            myLight.intensity -= lightFade * Time.deltaTime;
        }
    }
}
