using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public float health = 150f;
	
	//Enemy hit with rock
	void OnTriggerEnter2D(Collider2D col) {
		Projectile rock = col.gameObject.GetComponent<Projectile>();
		if (rock) {
			//Remove Damage From Enemy Health
			health -= rock.GetDamage();
			rock.Hit();
			//Kill Enemy if they run out of health
			if (health <= 0) {
				Destroy(gameObject);
			}
		}
	}
}
