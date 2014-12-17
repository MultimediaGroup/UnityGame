using UnityEngine;
using System.Collections;

public class TouchInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI (){
		string message = "";

		if (Input.touches.Length > 0) {
			message += "touchX: ";
			message += Input.GetTouch(0).position.x;
			message += "\ntouchY ";
			message += Input.GetTouch(0).position.y;
			message += "\nsreenW: ";
			message += Screen.width;
			message += "\nsreenH: ";
			message += Screen.height;
		}else{
			message += "No Touches";
		}
		
		GUI.Box (new Rect (0, 0, 500, 100), message);
	}
}
