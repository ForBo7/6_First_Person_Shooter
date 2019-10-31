using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float zoomedInFOV;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInSensitivity;
    [SerializeField] float zoomedOutSensitivity = 2f;

    RigidbodyFirstPersonController fpsController;

    private void Start()
    {
        fpsController = GetComponentInParent<RigidbodyFirstPersonController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ZoomFOV();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            ZoomOutFOV();
        }
    }

    private void OnDisable()
    {
        ZoomOutFOV();
    }

    private void ZoomFOV()
    {
        Camera.main.fieldOfView = zoomedInFOV;
        fpsController.mouseLook.XSensitivity = zoomedInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedInSensitivity;
    }

    private void ZoomOutFOV()
    {
        Camera.main.fieldOfView = zoomedOutFOV;
        fpsController.mouseLook.XSensitivity = zoomedOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedOutSensitivity;
    }
}
