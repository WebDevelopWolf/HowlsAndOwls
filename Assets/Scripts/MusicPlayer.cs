﻿using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;
	
	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip endClip;
	
	private AudioSource music;

	// Use this for initialization
	void Start () {
		if (instance != null) {
			Destroy(gameObject);
			print ("Duplicate Music Play Self-Destructing!");
		}
		else { 
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource>();
			music.clip = startClip;
			music.loop = true;
			music.Play();
		}
	}
	
	void OnLevelWasLoaded(int level) {
		Debug.Log("Music Player: loaded level " + level);
		music.Stop();
		if (level == 0) {
			music.clip = startClip;
		} else if (level == 1) {
			music.clip = gameClip;
		} else if (level == 2) {
			music.clip = endClip;
		}
		music.loop = true;
		music.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
