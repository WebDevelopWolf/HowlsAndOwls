using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	public static int incScore = 0;
	private Text text;
	
	void Start() {
		text = GetComponent<Text>();
		Reset();
	}
	
	public void UpdateScore(int points) {
		incScore += points;
		text.text = incScore.ToString();
	}
	
	public static void Reset() {
		incScore = 0;
	}
}
