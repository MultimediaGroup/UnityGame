using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Resume(){
		State.pause(false);
	}

	public void Restart(){
		State.restart();
	}

	public void Exit(){
		State.loadSplashScreen();
	}

	public void SetSound(bool onoff){

	}
}
