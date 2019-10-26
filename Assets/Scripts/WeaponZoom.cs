using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float zoomedInFOV;
    [SerializeField] float zoomedOutFOV;

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

    private void ZoomFOV()
    {
        Camera.main.fieldOfView = zoomedInFOV;
    }

    private void ZoomOutFOV()
    {
        Camera.main.fieldOfView = zoomedOutFOV;
    }
}
