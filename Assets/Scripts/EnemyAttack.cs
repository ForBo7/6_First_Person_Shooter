using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] AudioClip []attackSounds;

    AudioSource audioSource;
    PlayerHealth target;

    private void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
        audioSource = GetComponent<AudioSource>();
    }

    public void AttackHitEvent()
    {
        if (target == null) return; // To protect against null
        if (Random.Range(0,2) == 1)
        {
            audioSource.PlayOneShot(attackSounds[1]);
        }
        else
        {
            audioSource.PlayOneShot(attackSounds[0]);
        }
        target.TakeDamage(damage);
        target.GetComponent<DisplayBloodSplatter>().ShowBloodVFX();
    }
}
