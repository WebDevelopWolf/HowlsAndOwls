using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public float health = 150f;
	public GameObject projectile;
	public float projectileSpeed = 10f;
	public float shotsPerSecond = 0.5f;
	
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
	
	void Fire() {
		Vector3 startPosition = transform.position + new Vector3(0f, -1f, 0);
		GameObject rock = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;	
		rock.rigidbody2D.velocity = new Vector2(0f, -projectileSpeed);
	}
	
	void Update() {
		float probability = Time.deltaTime * shotsPerSecond;
		if (Random.value < probability) {
			Fire ();
		}
	}
}
