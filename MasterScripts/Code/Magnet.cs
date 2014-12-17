using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour {
	public float inputForce;
	public GameObject positive, negative;
	public string polarization, relativePosition;

	public int magnitudeThreshold;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftArrow)) {
			rigidbody.AddTorque(Camera.main.transform.forward * (inputForce * 50));
		}
		if(Input.GetKeyDown(KeyCode.RightArrow)) {
			rigidbody.AddTorque(Camera.main.transform.forward * (inputForce * -50));
		}
		if(Input.GetKeyDown(KeyCode.Space)) {
			Debug.Log ("Boosting");
			rigidbody.AddForce(Camera.main.transform.forward * inputForce * 50);
		}
		GameObject[] positives = GameObject.FindGameObjectsWithTag("Positive");
		GameObject[] negatives = GameObject.FindGameObjectsWithTag("Negative");
		foreach(GameObject go in positives) {
			Vector3 distanceFromPositive = go.transform.position - positive.transform.position;
			Vector3 distanceFromNegative = go.transform.position - negative.transform.position;
			float magnitudeFromPostive = distanceFromPositive.magnitude;
			float magnitudeFromNegative = distanceFromNegative.magnitude;
			bool positiveIsClosest;
			if(magnitudeFromPostive < magnitudeFromNegative) {
				positiveIsClosest = true;
			}
			else {
				positiveIsClosest = false;
			}
			if(magnitudeFromPostive < magnitudeThreshold && positiveIsClosest) {
				Debug.Log("Positive planet, positive part of magnet");
				rigidbody.AddForce((-1.0f / magnitudeFromPostive) * distanceFromPositive.normalized * 10);
			}
			if(magnitudeFromNegative < magnitudeThreshold && !positiveIsClosest) {
				Debug.Log("Positive planet, negative part of magnet");
				rigidbody.AddForce((1.0f / magnitudeFromPostive) * distanceFromPositive.normalized * 10);
			}	
		}
		foreach(GameObject go in negatives) {
			Vector3 distanceFromPositive = go.transform.position - positive.transform.position;
			Vector3 distanceFromNegative = go.transform.position - negative.transform.position;
			float magnitudeFromPostive = distanceFromPositive.magnitude;
			float magnitudeFromNegative = distanceFromNegative.magnitude;
			bool positiveIsClosest;
			if(magnitudeFromPostive < magnitudeFromNegative) {
				positiveIsClosest = true;
			}
			else {
				positiveIsClosest = false;
			}
			if(magnitudeFromPostive < magnitudeThreshold && positiveIsClosest) {
				Debug.Log("Negative planet, positive part of magnet");
				rigidbody.AddForce((1.0f / magnitudeFromPostive) * distanceFromPositive.normalized * 10);
			}
			if(magnitudeFromNegative < magnitudeThreshold && !positiveIsClosest) {
				Debug.Log("Negative planet, negative part of magnet");
				rigidbody.AddForce((-1.0f / magnitudeFromPostive) * distanceFromPositive.normalized * 10);
			}
		}
	}
	
	void FixedUpdate() {
		rigidbody.AddForce(Camera.main.transform.forward * inputForce / 2);
	}
	
	string checkRelativePosition(Vector3 position) {
		Vector3 relativePosition = transform.InverseTransformPoint(position);
		if(relativePosition.x < 0) {
			return "left";
		} else if(relativePosition.x > 0) {
			return "right";
		} else if(relativePosition.y > 0) {
			return "above";
		} else if(relativePosition.y < 0) {
			return "below";
		} else {
			return "front";
		}
	}
}
