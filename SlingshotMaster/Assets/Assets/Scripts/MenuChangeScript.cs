﻿using UnityEngine;
using System.Collections;

public class MenuChangeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Play(){
		State.loadLevel(1);

	}

	public void Exit(){
		State.endGame();
		
	}
}
