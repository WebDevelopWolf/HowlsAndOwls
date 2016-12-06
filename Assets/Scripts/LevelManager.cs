using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) { 
		Application.LoadLevel(name);
		Debug.Log ("Level load requested for: " + name);
	}
	
	public void QuitRequest () {
		Application.Quit();
		Debug.Log ("Quit game requested");
	}
	
	public void LoadNextLevel() {
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
