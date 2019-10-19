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
    Animation gunAnimation;

    private void Start()
    {
        gunAnimation = GetComponent<Animation>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);
        Debug.Log("Raycast has hit " + hit.transform.name);
    }

}
