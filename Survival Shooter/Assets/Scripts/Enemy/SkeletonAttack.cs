using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : EnemyAttack
{
    GameObject flameThrower;
    ParticleSystem explosion;

    bool isFiring;

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
            StartCoroutine(SetFlameThrower());
        }
    }

    IEnumerator SetFlameThrower()
    {
        flameThrower.SetActive(true);

        yield return new WaitForSeconds(5);

        flameThrower.SetActive(false);
    }


    bool PlayerInRange(Transform player)
    {
        return Vector3.Distance(player.position, transform.position) < 15;
    }

    override protected void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && PlayerInRange(player.transform) && enemyHealth.currentHealth > 0 && !isFiring)
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
