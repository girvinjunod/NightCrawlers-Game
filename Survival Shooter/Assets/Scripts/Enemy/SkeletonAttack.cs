using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : EnemyAttack
{
    GameObject flameThrower;
    ParticleSystem explosion;

    override protected void Awake()
    {
        base.Awake();
        flameThrower = gameObject.transform.GetChild(2).gameObject;
        explosion = GetComponentsInChildren<ParticleSystem>()[5];
    }

    override protected void Attack()
    {
        base.timer = 0f;

        if (playerHealth.currentHealth > 0)
        {
            flameThrower.SetActive(true);
        }
    }


    bool PlayerInRange(Transform player)
    {
        return Vector3.Distance(player.position, transform.position) < 15;
    }

    override protected void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && PlayerInRange(player.transform) && enemyHealth.currentHealth > 0)
        {
          Attack();
        }

        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }

        if(!PlayerInRange(player.transform))
        {
            flameThrower.SetActive(false);
        }

        if(enemyHealth.currentHealth <= 0)
        {
            explosion.Play();
            flameThrower.SetActive(false);
        }
    }

}
