using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberHealth : EnemyHealth
{
    ParticleSystem explosionParticles;
    override protected void Awake()
    {
        base.Awake();
        explosionParticles = GetComponentsInChildren<ParticleSystem>()[2];
    }

    override public void Death()
    {
        base.Death();
        explosionParticles.transform.position = transform.position;
        explosionParticles.Play();
    }

}
