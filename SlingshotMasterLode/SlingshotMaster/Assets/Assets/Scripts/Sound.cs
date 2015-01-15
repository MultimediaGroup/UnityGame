using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {
	public static AudioSource main;
	public static bool allowed;

	// Use this for initialization
	void Start () {
		main = audio;
		allowed = true;
		startMusic();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public static void playCollision() {
		if(allowed) {
			AudioClip clip = Resources.Load("collision1") as AudioClip;
			main.PlayOneShot(clip);
		}
	}
	
	public static void playMenu() {
		if(allowed) {
			AudioClip clip = Resources.Load("menu1") as AudioClip;
			main.PlayOneShot(clip);
		}
	}
	
	public static void startMusic(int track = 2) {
		Debug.Log ("music starting");
		if(allowed) {
			AudioClip clip = Resources.Load("music" + track) as AudioClip;
			main.clip = clip;
			main.Play();
		}
	}
	
	public static void stopPlaying() {
		if(allowed) {
			main.Stop();
		}
	}
}
