using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {
	
	//Get rid of rocks not hitting enemies
	void OnTriggerEnter2D(Collider2D col){
		Destroy(col.gameObject);
	}
}
