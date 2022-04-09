using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentHit : MonoBehaviour
{
    ParticleSystem hitParticles;

    void Awake()
    {
        hitParticles = GetComponentInChildren<ParticleSystem>();
    }

    public void ShowHit(Vector3 hitPoint)
    {
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();
    }
}
