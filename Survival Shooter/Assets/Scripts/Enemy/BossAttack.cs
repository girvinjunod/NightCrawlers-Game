using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : EnemyAttack
{
    override protected void Attack()
    {
        timer = 0f;
        if (playerHealth.currentHealth > 0)
        {
            base.anim.SetTrigger("Attack");
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
