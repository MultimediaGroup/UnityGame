using UnityEngine;
using System.Collections;

public class BtnLevel : MonoBehaviour {

	public GameObject menu;

	// Use this for initialization
	void Start () {
		menu.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnMouseDown () {
		if (Input.GetKey ("mouse 0")) {
			menu.renderer.enabled = true;
		}
	}
}
