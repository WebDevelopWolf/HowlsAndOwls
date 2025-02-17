﻿using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float speed = 5f;
	public float spawnDelay = 0.5f;
	
	private bool movingRight = true;
	private float xmin;
	private float xmax;

	// Use this for initialization
	void Start () {
		//Inital Enemy Spawn
		SpawnUntilFull();
		
		//Restrict Enemies to Play Space
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftBoundry = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightBoundry = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		xmax = rightBoundry.x;
		xmin = leftBoundry.x;
	}
	
	//Additional UI Wireframes
	public void OnDrawGizmos () {
		Gizmos.DrawWireCube(transform.position,new Vector3(width, height, 0));
	}
	
	// Update is called once per frame
	void Update () {
		//Move enemies from side to side
		if (movingRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		
		//Keep enemies inside play space and change direction
		float rightEdgeOfFormation = transform.position.x + (0.5f * width);
		float leftEdgeOfFormation = transform.position.x - (0.5f * width);
		if (leftEdgeOfFormation < xmin) { 
			movingRight = true;
		} else if (rightEdgeOfFormation > xmax) {
			movingRight = false;
		}
		
		//Respawn Enemies when on screen enimes are killed
		if (AllMembersDead()) {
			SpawnUntilFull();
		}
	}
	
	void SpawnUntilFull () {
		Transform freePosition = NextFreePosition();
		if (freePosition) {
			GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
		}
		if (NextFreePosition()) {
			Invoke("SpawnUntilFull", spawnDelay);
		}
	}
	
	bool AllMembersDead () {
		//Loop through enemies - if one alive return false if none return true
		foreach(Transform childPositionGameObject in transform) {
			//Alive = 1 || Dead = 0
			if (childPositionGameObject.childCount > 0) {
				return false;
			} 
		}
		return true;
	}
	
	Transform NextFreePosition () {
		//Loop through enemies
		foreach(Transform childPositionGameObject in transform) {
			//When there is no enemy - spane a new one
			if (childPositionGameObject.childCount == 0) {
				return childPositionGameObject;
			} 
		}
		return null;
	}
}
