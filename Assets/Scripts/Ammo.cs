using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount;

    public void ReduceCurrentAmmo()
    {
        ammoAmount--;
    }

    public int GetAmmoAmount()
    {
        return ammoAmount;
    }
}
