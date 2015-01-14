using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {
	public static AudioSource main;

	// Use this for initialization
	void Start () {
		main = audio;
		startMusic(2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public static void playCollision() {
		AudioClip clip = Resources.Load("collision1") as AudioClip;
		main.PlayOneShot(clip);
	}
	
	public static void playMenu() {
		AudioClip clip = Resources.Load("menu1") as AudioClip;
		main.PlayOneShot(clip);
	}
	
	public static void startMusic(int track = 1) {
		AudioClip clip = Resources.Load("music" + track) as AudioClip;
		main.clip = clip;
		main.Play();
	}
	
	public static void stopPlaying() {
		main.Stop();
	}
}
