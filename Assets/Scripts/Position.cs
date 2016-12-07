using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {
	
	//Additional UI elements
	void OnDrawGizmos() {
		Gizmos.DrawWireSphere(transform.position, 1);
	}
}
