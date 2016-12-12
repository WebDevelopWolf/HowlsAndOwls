using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text text = GetComponent<Text>();
		text.text = Score.incScore.ToString();
		Score.Reset();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
