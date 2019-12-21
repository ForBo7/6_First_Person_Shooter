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
    float currentLightIntensity;
    float currentLightAngle;
    bool isFlashLightOn;

    private void Start()
    {
        myLight = GetComponent<Light>();
        currentLightIntensity = myLight.intensity;
        currentLightAngle = myLight.spotAngle;
        myLight.intensity = 0f;
        myLight.spotAngle = 0f;
    }

    private void Update()
    {
        DecreaseLightIntensity();
        DecreaseLightAngle();
        TurnOnFlashLight();
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        myLight.spotAngle = restoreAngle;
        currentLightAngle = restoreAngle;
    }

    public void RestoreLightIntensity(float restoreIntensity)
    {
        myLight.intensity = restoreIntensity;
        currentLightIntensity = restoreIntensity;
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
            currentLightAngle = myLight.spotAngle;
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
            currentLightIntensity = myLight.intensity;
        }
    }

    private void TurnOnFlashLight() 
    {
        if(Input.GetKeyDown(KeyCode.F) && isFlashLightOn)
        {
            myLight.intensity = 0f;
            myLight.spotAngle = 0f;
            isFlashLightOn = false;
        }
        else if(Input.GetKeyDown(KeyCode.F) && !isFlashLightOn) 
        {
            myLight.intensity = currentLightIntensity;
            myLight.spotAngle = currentLightAngle;
            isFlashLightOn = true;
        }
    }

}
