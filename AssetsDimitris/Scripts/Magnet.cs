using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour {
	public float inputForce;
	public GameObject positive, negative;
	public Vector3 relativePosition;
	public bool rotating = false;
	public float radsPerSecs =0;

	public float radius = 0;
	public float g = 0;
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
			rigidbody.AddForce(Camera.main.transform.forward * inputForce * 50);
		}
		GameObject[] positives = GameObject.FindGameObjectsWithTag("Positive");
		GameObject[] negatives = GameObject.FindGameObjectsWithTag("Negative");
		foreach(GameObject go in positives) {
			Vector3 distanceFromPositive = go.transform.position - positive.transform.position;
			Vector3 distanceFromNegative = go.transform.position - negative.transform.position;
			float magnitudeFromPostive = distanceFromPositive.magnitude;
			float magnitudeFromNegative = distanceFromNegative.magnitude;
			bool positiveIsClosest = magnitudeFromPostive < magnitudeFromNegative;

			Debug.Log (magnitudeFromPostive - magnitudeFromNegative);
			if(magnitudeFromPostive < radius && positiveIsClosest) {
				rigidbody.AddForce((-1.0f / magnitudeFromPostive) * distanceFromPositive.normalized * g);
				Vector3 nullZ = new Vector3(go.transform.position.x - transform.position.x, go.transform.position.y - transform.position.y, transform.position.z);
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(nullZ), radsPerSecs * Time.deltaTime);
			}
			if(magnitudeFromNegative < radius && !positiveIsClosest) {
				rigidbody.AddForce((1.0f / magnitudeFromNegative) * distanceFromNegative.normalized * g);

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
			if(magnitudeFromPostive < radius && positiveIsClosest) {
				rigidbody.AddForce((1.0f / magnitudeFromPostive) * distanceFromPositive.normalized * g);
				Vector3 nullZ = new Vector3(go.transform.position.x - transform.position.x, go.transform.position.y - transform.position.y, transform.position.z);
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(nullZ), radsPerSecs * Time.deltaTime);
			}
			if(magnitudeFromNegative < radius && !positiveIsClosest) {
				rigidbody.AddForce((-1.0f / magnitudeFromNegative) * distanceFromNegative.normalized * g);
			}
		}
	}
	
	void FixedUpdate() {
		if(!rotating) {
			rigidbody.AddForce(Camera.main.transform.forward * inputForce / 2);
		}
	}

	/*
	 * Debug.Log (positiveIsClosest);
			if(magnitudeFromPostive < radius && positiveIsClosest) {
				//Debug.Log("Positive planet, positive part of magnet");
				rigidbody.AddForce((-1.0f / magnitudeFromPostive) * distanceFromPositive.normalized * g);
				//transform.eulerAngles = new Vector3(0, Vector3.Angle(transform.position, go.transform.position), 0);
				//transform.LookAt(go.transform.position);
				//transform.Rotate(new Vector3(0, -90, 0));
				//transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
			}
			if(magnitudeFromNegative < radius && !positiveIsClosest) {
				//Debug.Log("Positive planet, negative part of magnet");
				rigidbody.AddForce((1.0f / magnitudeFromNegative) * distanceFromNegative.normalized * g);
				/*
				Vector3 newDir = Vector3.RotateTowards(transform.position, go.transform.position - transform.position, radsPerSecs * Time.deltaTime, 0f);
				transform.rotation = Quaternion.LookRotation(newDir);
				*/
	
	//Vector3 nullZ = new Vector3(go.transform.position.x - transform.position.x, go.transform.position.y - transform.position.y, transform.position.z);
	//transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(nullZ), radsPerSecs * Time.deltaTime);
	/*Vector3 idX = new Vector3(1,0,0);
				Vector3 idY = new Vector3(0,1,0);
				Vector3 idZ = new Vector3(0,0,1);
				*/
	//rigidbody.AddTorque(-Vector3.Angle(transform.position, go.transform.position) / 40, -Vector3.Angle(transform.position, go.transform.position) / 40, -Vector3.Angle(transform.position, go.transform.position) / 40);
	//rigidbody.AddTorque(-Vector3.Angle(transform.position * idX, go.transform.position * idX) / 40, -Vector3.Angle(transform.position * idY, go.transform.position * idY) / 40, -Vector3.Angle(transform.position * idZ, go.transform.position * idZ) / 40);
	
	/*
				Vector3 relative = (go.transform.position + new Vector3(0, 1.5f, 0)) - transform.position;
				Quaternion rotation = Quaternion.LookRotation(relative);
				Quaternion current = transform.localRotation;
				transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
				*/
	//transform.Translate(0, 0, 3 * Time.deltaTime);
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
