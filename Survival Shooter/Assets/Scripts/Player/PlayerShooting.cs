using UnityEngine;
// using System;
public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public static float timeBetweenBullets = 0.5f;
    public float range = 100f;

    public static int critChance = 0;
    public static int bulletCount = 5;

    public GameObject bullets;
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

        critChance = 0;
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
        gunLine.positionCount = bulletCount*2;
        // gunLine.enabled = true;

        for(int bullet = 0; bullet < bulletCount; bullet++){

            int factor = bulletCount == 5 ? 2 : (bulletCount == 3 ? 1 : 0);
            factor = bullet - factor;
            float yRot = 15 * factor;
            Quaternion q = Quaternion.AngleAxis(yRot, Vector3.up);
            shootRay.origin = transform.position;
            shootRay.direction = q * transform.forward;
            int index = bullet==0 ? 0 : bullet*2;
            // gunLine.SetPosition(index, transform.position);

            Instantiate(bullets, transform.position, q * transform.rotation);
            
            // if (Physics.Raycast(shootRay.origin,shootRay.direction, out shootHit, range, shootableMask))
            // {
            //     EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

            //     if (enemyHealth != null)
            //     {
            //         int rand = Random.Range(0, 100);
            //         if (rand < critChance)
            //         {
            //             critAudio.Play();
            //             isCrit = true;
            //         }
            //         if (isCrit)
            //         {
            //             Debug.Log("Crit");
            //             enemyHealth.TakeDamage(damagePerShot * 2, shootHit.point);

            //         }
            //         else
            //         {
            //             enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            //         }
            //     }

            //     gunLine.SetPosition(index + 1, shootHit.point);
            // }
            // else
            // {
            //     gunLine.SetPosition(index + 1, shootRay.origin + shootRay.direction * range);
            // }
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