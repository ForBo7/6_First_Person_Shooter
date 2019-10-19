using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Why on planet earth does this commented out code give errors??????

    //[SerializeField] Camera FPCamera;
    //[SerializeField] float range;

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Shoot();
    //    }
    //}

    //private static void Shoot()
    //{
    //    RaycastHit hit;
    //    Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);
    //    print("Raycast has hit " + hit.transform.name);
    //}

    [SerializeField] Camera FPCamera;
    [SerializeField] float range;
    [SerializeField] float gunDamage;
    [SerializeField] ParticleSystem muzzleFlash;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log("Raycast has hit " + hit.transform.name);
            // TODO: add some hit effect for visual feedback
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return; // So that a null error does not appear if a target has no enemy health script
            target.TakeDamage(gunDamage);
        }
        else
        {
            return;
        }
    }
}
