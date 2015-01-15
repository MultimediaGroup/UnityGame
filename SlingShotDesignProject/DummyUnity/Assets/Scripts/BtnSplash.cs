using UnityEngine;
using System.Collections;

public class BtnSplash : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnMouseDown () {
		if (Input.GetKey ("mouse 0")) {
			Application.LoadLevel("level1");
		}
	}

}
