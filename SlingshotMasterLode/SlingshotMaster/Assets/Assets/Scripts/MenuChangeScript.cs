using UnityEngine;
using System.Collections;

public class MenuChangeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Sound.startMusic();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Play(){
		Sound.playMenu();
		State.loadLevel(1);

	}

	public void Exit(){
		Sound.playMenu();
		State.endGame();
		
	}
}
