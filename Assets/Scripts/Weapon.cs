using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range;
    [SerializeField] float gunDamage;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject bulletSparks;
    [SerializeField] float timeBetweenShots;
    [SerializeField] AmmoType ammoType;

    bool canShoot = true;

    private void OnEnable()
    {
        if (canShoot == false)
        {
            Invoke("SetCanShootTrue", timeBetweenShots);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (GetComponent<Ammo>().GetAmmoAmount(ammoType) != 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            GetComponent<Ammo>().ReduceCurrentAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void SetCanShootTrue()
    {
        canShoot = true;
    }
}
