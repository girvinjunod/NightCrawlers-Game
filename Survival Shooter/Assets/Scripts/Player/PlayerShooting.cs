using UnityEngine;
// using System;
public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;

    public static int critChance = 0;

    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource[] gunAudioArr;
    AudioSource gunAudio;
    AudioSource critAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;

    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudioArr = GetComponents<AudioSource>();
        gunAudio = gunAudioArr[0];
        critAudio = gunAudioArr[1];
        gunLight = GetComponent<Light>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && PauseMenu.GameIsPaused == false && UpgradeMenu.IsUpgradeNow == false)
        {
            Shoot();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
    }

    public void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

    void Shoot()
    {
        bool isCrit = false;
        timer = 0f;


        gunAudio.Play();

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                int rand = Random.Range(0, 100);
                if (rand < critChance)
                {
                    critAudio.Play();
                    isCrit = true;
                }
                if (isCrit)
                {
                    Debug.Log("Crit");
                    enemyHealth.TakeDamage(damagePerShot * 2, shootHit.point);

                }
                else
                {
                    enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                }
            }

            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
    public void powerOrb()
    {
        if (damagePerShot < 200)
        {
            damagePerShot += 10;
            PowerManager.power += 1;
        }
    }
}