using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints;

    // create a public method which reduces hitpoints by the amount of damage

    public void TakeDamage(float gunDamage)
    {
        BroadcastMessage("OnDamageTaken");

        hitPoints -= gunDamage;

        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

}
