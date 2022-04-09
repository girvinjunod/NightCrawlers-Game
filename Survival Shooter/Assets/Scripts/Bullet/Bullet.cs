using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100.0f;
    public int damage = 20;

    float timer;
    	Vector3 velocity;
      Vector3 force;
      Vector3 newPos;
      Vector3 oldPos;
      Vector3 direction;

      RaycastHit lastHit;
      bool hasHit = false;
      PlayerShooting playerShooting;
      GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerShooting = player.GetComponentInChildren <PlayerShooting> ();      
        damage = playerShooting.damagePerShot;      
        newPos = transform.position;
		    oldPos = newPos;
    }

    // Update is called once per frame
    void Update()
    {
		if (hasHit) {
			return;
		}

		// Add the time since Update was last called to the timer.
		timer += Time.deltaTime;

		// Schedule for destruction if bullet never hits anything.
		// if (timer >= life) {
		// 	Dissipate();
		// }

        velocity = transform.forward;
		velocity.y = 0;
		velocity = velocity.normalized * speed;

		// assume we move all the way
		newPos += velocity * Time.deltaTime;
	
		// Check if we hit anything on the way
		direction = newPos - oldPos;
		float distance = direction.magnitude;

		if (distance > 0) {
            RaycastHit[] hits = Physics.RaycastAll(oldPos, direction, distance);

		    // Find the first valid hit
		    for (int i = 0; i < hits.Length; i++) {
		        RaycastHit hit = hits[i];

				// if (ShouldIgnoreHit(hit)) {
				// 	continue;
				// }

				// notify hit
				OnHit(hit);

				lastHit = hit;

				if (hasHit) {
					newPos = hit.point;
					break;
				}
		    }
		}

		oldPos = transform.position;
		transform.position = newPos;        
    }

    void OnHit(RaycastHit hit) {
        hasHit = true;
        EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
			
		// If the EnemyHealth component exist...
		if (enemyHealth != null) {
			// ... the enemy should take damage.
			enemyHealth.TakeDamage(damage, hit.point);
		}

		EnvironmentHit envHit = hit.collider.GetComponent<EnvironmentHit>();
		// If the hitParticles component exist...
		if(envHit != null)
        {
			envHit.ShowHit(hit.point);
        }
      Destroy(gameObject);
    }

    void DelayedDestroy() {
		    Destroy(gameObject, 0.2f);
	}
}
