using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float damage;

    public void AttackHitEvent()
    {
        if (target == null)
        {
            return; // to protect against null
        }
        Debug.Log("Boop!");
    }

}
