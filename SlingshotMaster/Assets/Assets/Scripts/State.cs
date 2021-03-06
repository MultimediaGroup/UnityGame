﻿using UnityEngine;
using System.Collections;

public class State : MonoBehaviour {

	//STATES:
	//-1: game over
	//0: on splashscreen
	//1: playing a level
	//2: on menu


	public static int state;
	public static int level;
	public static float outOfBoundsTimer;
	public static string currentLevel;
	public static GameObject player;
	public static bool isOutOfBounds;

	public static GameObject menu;

	private static Vector3 previousSpeed = Vector3.zero;

	// Use this for initialization
	void Start () {
		state = 1;
		level = 1;
		updateCurrentLevel();
		player = GameObject.FindGameObjectWithTag("Player");
		menu = GameObject.Find("Menu");
		if(menu)
			menu.SetActive(false);
		outOfBoundsTimer = 10;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnGUI() {
		if(state == 1) {
			if(isOutOfBounds) {
				if(outOfBoundsTimer > 0) {
					outOfBoundsTimer -= 1 * Time.deltaTime;
					GUI.Label(new Rect (0,0,100,100), outOfBoundsTimer.ToString());
				}
				else {
					isOutOfBounds = false;
					outOfBoundsTimer = 10;
					restart();
				}
			}
		}
	}
	
	public static void loadSplashScreen() {
		Application.LoadLevel("splashscreen");
		state = 0;
		updateCurrentLevel();
	}
	
	public static void loadLevel(int levelNumber) {
		Application.LoadLevel("level" + levelNumber);
		state = 1;
		updateCurrentLevel();
	}

	public static void nextLevel(){
		loadLevel(++level);
	}

	public static void pause(bool pause) {
		if(state == 1) {
			if(pause) {
				previousSpeed = player.rigidbody.velocity;
				player.rigidbody.isKinematic = true;
			}
			else {
				player.rigidbody.isKinematic = false;
				player.rigidbody.velocity = previousSpeed;
			}
		}
	}
	
	public static void restart() {
		if(state == 1) {
			Application.LoadLevel(currentLevel);
		}
	}
	
	public static void outOfBounds() {
		if(state == 1) {
			isOutOfBounds = true; 
		}
	}
	
	public static void gameOver() {
		player.rigidbody.isKinematic = true;
		state = -1;
	}

	public static void endGame(){
		Application.Quit();
	}
	
	public static void updateCurrentLevel() {
		currentLevel = Application.loadedLevelName;
	}

	public static void pauseMenu(){
		if(!player.rigidbody.isKinematic) {
			pause(true);
			//Debug.Log(GameObject.Find("Menu"));
			//GameObject menu = GameObject.Find("Menu");
			menu.SetActive(true);
		}else{
			pause(false);
			menu.SetActive(false);
		}
	}
}
