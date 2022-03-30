using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberAttack : EnemyAttack
{
    ParticleSystem explosionParticles;

    override protected void Awake()
    {
        base.Awake();
        explosionParticles = GetComponentsInChildren<ParticleSystem>()[2];
    }

    override protected void Attack()
    {
        timer = 0f;

        if (playerHealth.currentHealth > 0)
        {
            explosionParticles.transform.position = transform.position;
            explosionParticles.Play();

            playerHealth.TakeDamage(attackDamage);

            base.enemyHealth.currentHealth = 0;
            base.enemyHealth.Death();
            base.enemyHealth.isSuicide = true;
        }
    }
}

