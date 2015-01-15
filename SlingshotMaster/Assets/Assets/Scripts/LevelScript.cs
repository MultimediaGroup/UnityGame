﻿using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour {

	public GameObject go;
	public GameObject ready;
	public GameObject vortex;
	public int needToCollect;

	public GameObject score;

	private float readyTimer = 2f;
	private float goTimer = 1.5f;
	private bool playLevel = false;
	private int collected = 0;

	// Use this for initialization
	void Start () {
		go.SetActive(false);
		score.GetComponent<GUIText>().text = collected + "/" + needToCollect;
	}
	
	// Update is called once per frame
	void Update () {
		if(!playLevel){
			Debug.Log("paused");
			State.pause(true);
		}
		if(readyTimer > 0.2f){
			ready.GetComponent<RectTransform>().localScale = new Vector3(readyTimer, readyTimer, readyTimer);
			readyTimer -= Time.deltaTime;
		}else{
			if(ready.activeSelf){
				ready.SetActive(false);

				go.SetActive(true);
			}
			if(goTimer > 0.8f){
				go.GetComponent<RectTransform>().localScale = new Vector3(goTimer, goTimer, goTimer);
				goTimer -= Time.deltaTime;
			}else{
				go.SetActive(false);
				State.pause(false);
				playLevel = true;
			}
		}
	}

	public void Collect(){
		if(++collected == needToCollect){
			OpenVortex();
		}
		score.GetComponent<GUIText>().text = collected + "/" + needToCollect;
	}	

	public void OpenVortex(){
		vortex.SetActive(true);
	}
}
