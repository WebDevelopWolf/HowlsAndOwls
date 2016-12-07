using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float speed = 5f;
	
	private bool movingRight = true;
	private float xmin;
	private float xmax;

	// Use this for initialization
	void Start () {
		//Spawn Enemies on Placeholders
		foreach(Transform child in transform) {
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
		
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
	}
}
