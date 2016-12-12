using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	public int incScore = 0;
	private Text text;
	
	void Start() {
		text = GetComponent<Text>();
		Reset();
	}
	
	public void UpdateScore(int points) {
		incScore += points;
		text.text = incScore.ToString();
	}
	
	public void Reset() {
		incScore = 0;
		text.text = incScore.ToString();
	}
}
