using UnityEngine;
using System.Collections;

public class SplashTitle : MonoBehaviour
{

		public GameObject fadeBlack;

		// Use this for initialization
		void Start ()
		{
				iTween.FadeTo (fadeBlack, iTween.Hash ("alpha", 0, "time", 1));
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
	
		void OnMouseDown ()
		{
				Debug.Log ("check");
				iTween.FadeTo (gameObject, iTween.Hash ("alpha", 0, "time", 2));
				iTween.FadeTo (fadeBlack, iTween.Hash ("alpha", 1, "time", 2, "oncomplete", "LoadLevel", "oncompletetarget", gameObject));
		}

		void LoadLevel ()
		{
				Application.LoadLevel ("Level1");
		}
}
