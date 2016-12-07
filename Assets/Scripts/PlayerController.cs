using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 15.0f;
	public GameObject projectile;
	public float projectileSpeed;
	public float firingRate = 0.2f;
	
	private float xmin;
	private float xmax;

	// Use this for initialization
	void Start () {
		//Restrict Player to Play Space
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		xmin = leftmost.x;
		xmax = rightmost.x;
	}
	
	//Fire Projectile
	void Fire () {
		GameObject rock = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		rock.rigidbody2D.velocity = new Vector3(0, projectileSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		//Move player side to side based on keyboard input
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		
		//Restrict Player to Play Space
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
		
		//Restrict Fire
		if (Input.GetKeyDown(KeyCode.Space)) {
			InvokeRepeating("Fire", 0.000001f, firingRate);
		}
		if (Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke("Fire");	
		}
	}
}
