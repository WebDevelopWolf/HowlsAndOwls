﻿using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public float health = 150f;
	public GameObject projectile;
	public float projectileSpeed = 10f;
	public float shotsPerSecond = 0.5f;
	public int scoreValue = 150;
	public AudioClip fireSound;
	public AudioClip dieSound;
	
	private Score scoreKeeper;
	
	void Start() {
		scoreKeeper = GameObject.Find("Score").GetComponent<Score>();
	}
	
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
				scoreKeeper.UpdateScore(scoreValue);
				AudioSource.PlayClipAtPoint(dieSound, transform.position);
			}
		}
	}
	
	void Fire() {
		Vector3 startPosition = transform.position + new Vector3(0f, -1f, 0);
		GameObject rock = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;	
		rock.rigidbody2D.velocity = new Vector2(0f, -projectileSpeed);
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}
	
	void Update() {
		float probability = Time.deltaTime * shotsPerSecond;
		if (Random.value < probability) {
			Fire ();
		}
	}
}
