using UnityEngine;
using System.Collections;

public class RotateInertiaController : MonoBehaviour {

	public float sensitivity = 1;
	public float friction = 0.5f;
	
	private Vector2 previousTouch = Vector2.zero;
	private Vector2 currentTouch = Vector2.zero;
	private float inertia = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Touch[] touches = Input.touches;
		
		if (touches.Length > 0) {
			if(touches[0].phase == TouchPhase.Began){
				previousTouch = Vector2.zero;
			}
			
			if(previousTouch == Vector2.zero){
				previousTouch = touches[0].position;
			}else{
				currentTouch = touches[0].position;

				Vector2 deltaTouch = currentTouch - previousTouch;
				//Touch is Right
				if(currentTouch.x > Screen.width / 2 && previousTouch.x > Screen.width/2){
					inertia += (currentTouch.y - previousTouch.y) * sensitivity;
				}
				//Touch is Left
				else if(currentTouch.x  < Screen.width / 2 && previousTouch.x < Screen.width/2){
					inertia += -(currentTouch.y - previousTouch.y) * sensitivity;
				}

				transform.Rotate(new Vector3(0,0,inertia));
				//compare touches
				
				inertia *=  friction;
				
				//Finish
				
				previousTouch = currentTouch;
			}
		}

		
		
		transform.Rotate(new Vector3(0,0,inertia));
		//compare touches
		
		inertia *=  friction;
	}
	
	void OnGUI(){
		GUI.Box (new Rect (0, 0, 500, 100), Debug());
	}
	
	string Debug(){
		string message = "";
		
		message += "isLeft?: ";
		message += (currentTouch.x < Screen.width / 2 && previousTouch.x < Screen.width / 2);
		
		message += "RotateVectorRight: ";
		message += new Vector3 (0, 0, (currentTouch.y - previousTouch.y) * sensitivity);
		
		message += "RotateVectorLeft: ";
		message += new Vector3 (0, 0, -(currentTouch.y - previousTouch.y) * sensitivity);
		
		return message;
	}
}
