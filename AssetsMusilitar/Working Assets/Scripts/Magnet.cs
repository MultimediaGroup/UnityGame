using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour {
	public float inputForce;
	public GameObject positive, negative;
	public Vector3 previousPosition, relativePosition;
	public bool rotating = false;

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
			if(magnitudeFromPostive < 7 && positiveIsClosest) {
				//Debug.Log("Positive planet, positive part of magnet");
				rigidbody.AddForce((-1.0f / magnitudeFromPostive) * distanceFromPositive.normalized * 5);
				//transform.eulerAngles = new Vector3(0, Vector3.Angle(transform.position, go.transform.position), 0);
				//transform.LookAt(go.transform.position);
				//transform.Rotate(new Vector3(0, -90, 0));
				//transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
			}
			if(magnitudeFromNegative < 7 && !positiveIsClosest) {
				//Debug.Log("Positive planet, negative part of magnet");
				rigidbody.AddForce((1.0f / magnitudeFromNegative) * distanceFromNegative.normalized * 5);
				rigidbody.AddTorque(0, 0, -Vector3.Angle(transform.position, go.transform.position) / 100);
				/*Vector3 relative = (go.transform.position + new Vector3(0, 1.5f, 0)) - transform.position;
				Quaternion rotation = Quaternion.LookRotation(relative);
				Quaternion current = transform.localRotation;
				transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
				transform.Translate(0, 0, 3 * Time.deltaTime);*/
				/*Quaternion rotation = Quaternion.LookRotation(go.transform.position - transform.position);
				transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime );
				transform.Translate(Vector3.forward * Time.deltaTime * inputForce);*/
				/*transform.RotateAround (go.transform.position, Vector3.up, 20 * Time.deltaTime);
				Vector3 desiredPosition = (transform.position - go.transform.position).normalized * 2 + go.transform.position;
				transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * 0.5f);*/
				//transform.RotateAround(go.transform.position, Vector3.up, -0.5f);
				/*Quaternion rotation = Quaternion.LookRotation(distanceFromNegative.normalized);
				Quaternion current = transform.localRotation;
				transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);*/
				//transform.eulerAngles = new Vector3(0, Vector3.Angle(transform.position, go.transform.position), 0);
				//transform.position = Vector3.Lerp(transform.position, go.transform.position, Time.deltaTime);
				//transform.LookAt(go.transform.position);
				//transform.eulerAngles = new Vector3(0, -Vector3.Angle(transform.position, go.transform.position), 0);
				//transform.Rotate(new Vector3(0, magnitudeFromNegative * 45, 0));
				//transform.RotateAround(Vector3.zero, Vector3.up, -20 * Time.deltaTime);
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
			if(magnitudeFromPostive < 7 && positiveIsClosest) {
				//Debug.Log("Negative planet, positive part of magnet");
				rigidbody.AddForce((1.0f / magnitudeFromPostive) * distanceFromPositive.normalized * 5);
				rigidbody.AddTorque(0, -Vector3.Angle(transform.position, go.transform.position) / 40, 0);
				/*Vector3 relative = (go.transform.position + new Vector3(0, 1.5f, 0)) - transform.position;
				Quaternion rotation = Quaternion.LookRotation(relative);
				Quaternion current = transform.localRotation;
				transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
				transform.Translate(0, 0, 3 * Time.deltaTime);*/
				/*Quaternion rotation = Quaternion.LookRotation(go.transform.position - transform.position);
				transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime );
				transform.Translate(Vector3.forward * Time.deltaTime * inputForce);*/
				/*transform.RotateAround (go.transform.position, Vector3.up, 20 * Time.deltaTime);
				Vector3 desiredPosition = (transform.position - go.transform.position).normalized * 2 + go.transform.position;
				transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * 0.5f);*/
				//rotating = true;
				//transform.RotateAround(go.transform.position, Vector3.up, -2 * Time.deltaTime);
				/*Quaternion rotation = Quaternion.LookRotation(distanceFromNegative.normalized);
				Quaternion current = transform.localRotation;
				transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);*/
				//transform.eulerAngles = new Vector3(0, Vector3.Angle(transform.position, go.transform.position), 0);
				//Vector3 target = go.transform.position + new Vector3(0, 0, go.renderer.bounds.size.x);
				//transform.position = Vector3.Slerp(transform.position, target, 0.001f);
				//transform.LookAt(go.transform.position);
				//transform.eulerAngles = new Vector3(0, -Vector3.Angle(transform.position, go.transform.position), 0);
				//transform.Rotate(new Vector3(0, magnitudeFromPostive * 45, 0));
				//transform.RotateAround(Vector3.zero, Vector3.up, -20 * Time.deltaTime);
			}
			if(magnitudeFromNegative < 7 && !positiveIsClosest) {
				//Debug.Log("Negative planet, negative part of magnet");
				rigidbody.AddForce((-1.0f / magnitudeFromNegative) * distanceFromNegative.normalized * 5);
				//transform.eulerAngles = new Vector3(0, Vector3.Angle(transform.position, go.transform.position), 0);
				//transform.LookAt(go.transform.position);
				//transform.Rotate(new Vector3(0, -90, 0));
				//transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
			}
		}
	}
	
	void FixedUpdate() {
		if(!rotating) {
			rigidbody.AddForce(Camera.main.transform.forward * inputForce / 2);
		}
	}
}
