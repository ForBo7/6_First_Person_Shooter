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
    [SerializeField] GameObject bulletSparks;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (GetComponent<Ammo>().GetAmmoAmount() != 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            GetComponent<Ammo>().ReduceCurrentAmmo();
        }
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
            PlayBulletSparks(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return; // So that a null error does not appear if a target has no enemy health script
            target.TakeDamage(gunDamage);
        }
        else
        {
            return;
        }
    }

    private void PlayBulletSparks(RaycastHit hit)
    {
        GameObject instantiatedBulletSparks = Instantiate(bulletSparks, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(instantiatedBulletSparks, 1f);
    }
}
