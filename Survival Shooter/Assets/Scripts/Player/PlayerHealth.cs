using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);


    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    bool isDead;                                                
    bool damaged;                                               


    void Awake()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponentInChildren<PlayerShooting>();

        currentHealth = startingHealth;
    }


    void Update()
    {
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damaged = false;
    }


    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        HPBarManager.health = currentHealth;
        healthSlider.value =  (Convert.ToSingle(HPBarManager.health)/Convert.ToSingle(HPBarManager.maxHealth)) * 100;


        playerAudio.Play();

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        playerShooting.DisableEffects();

        anim.SetTrigger("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }

    public void healthOrb(){
        if (HPBarManager.maxHealth < 300){
            currentHealth += 20;
            HPBarManager.health += 20;
            HPBarManager.maxHealth += 20;
            healthSlider.value =  (Convert.ToSingle(HPBarManager.health)/Convert.ToSingle(HPBarManager.maxHealth)) * 100;
        }  else {
            currentHealth += 20;
            HPBarManager.health += 20;
            healthSlider.value =  (Convert.ToSingle(HPBarManager.health)/Convert.ToSingle(HPBarManager.maxHealth)) * 100;
        }    
    }
    // public void RestartLevel() {
    //     SceneManager.LoadScene(0);
    // }
}
