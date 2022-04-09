using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum PickupType {Power, Speed, Health};

    public PickupType pickupType = PickupType.Power;
    GameObject player;
    bool playerInRange;
    protected PlayerHealth playerHealth;
    protected PlayerShooting playerShooting;
    protected PlayerMovement playerMovement;

    public float delay = 30f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        playerShooting = player.GetComponentInChildren <PlayerShooting> ();
        playerMovement = player.GetComponentInChildren <PlayerMovement> ();
     
        StartCoroutine(SelfDestruct());
        // enemyHealth = GetComponent<EnemyHealth>();
        // anim = GetComponent <Animator> ();
    }
    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player && other.isTrigger == false)
        {
            playerInRange = true;
        }       
    }

    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(playerInRange)
        {
            PickupManager.usedSpawnPoints.Remove(transform.position);            
            // Debug.Log(transform.position);
            switch (pickupType) {
              case PickupType.Power:
                playerShooting.powerOrb();
                break;
                
              case PickupType.Speed:
                playerMovement.speedOrb();
                break;
                
              case PickupType.Health:
                playerHealth.healthOrb();
                break;
            }
            Destroy(gameObject,0f);
        } 
    } 
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(delay);
        PickupManager.usedSpawnPoints.Remove(transform.position); 
        Destroy(gameObject);
    }
}
