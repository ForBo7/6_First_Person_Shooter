using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints;

    bool isDead;

    public void TakeDamage(float gunDamage)
    {
        BroadcastMessage("OnDamageTaken");

        hitPoints -= gunDamage;

        if (hitPoints <= 0)
        {
            if (isDead) return; // so that the code below does not keep executing
            isDead = true;
            GetComponent<Animator>().SetTrigger("Dead");
        }
    }

    public bool IsDead()
    {
        return isDead;
    }
}
