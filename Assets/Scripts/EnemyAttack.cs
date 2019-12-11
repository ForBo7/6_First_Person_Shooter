using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage;

    PlayerHealth target;

    private void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (target == null) return; // To protect against null
        target.TakeDamage(damage);
        target.GetComponent<DisplayBloodSplatter>().ShowBloodVFX();
    }
}
