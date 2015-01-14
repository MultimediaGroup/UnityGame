using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour {
	public float inputForce, magnetForce;
	public float sphereCastRadius, sphereCastDistance;
	public float rotationSpeed;
	public GameObject positive, negative;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftArrow)) {
			rigidbody.AddTorque(new Vector3(0, 0, inputForce * 50));
		}
		if(Input.GetKeyDown(KeyCode.RightArrow)) {
			rigidbody.AddTorque(new Vector3(0, 0, inputForce * -50));
		}
		if(Input.GetKeyDown(KeyCode.Space)) {
			rigidbody.AddForce(new Vector3(0, 0, inputForce * 50));
		}
		
		RaycastHit hit;
		if(Physics.SphereCast(transform.position, sphereCastRadius, transform.forward, out hit, sphereCastDistance)) {
			float distanceToObstacle = hit.distance;
			if(distanceToObstacle < 1) {
				Transform otherTransform = hit.transform;
				float magnitudePositive = (otherTransform.position - positive.transform.position).magnitude;
				float magnitudeNegative = (otherTransform.position - negative.transform.position).magnitude;
				string obstacleTag = hit.collider.gameObject.tag;
				if(obstacleTag == "Positive") {
					if(magnitudePositive < magnitudeNegative) {
						rigidbody.AddForce((-1.0f / magnitudePositive) * (otherTransform.position - positive.transform.position).normalized * magnetForce);
					}
					else {
						rigidbody.AddForce((1.0f / magnitudeNegative) * (otherTransform.position - negative.transform.position).normalized * magnetForce);

						Vector3 direction = (otherTransform.position - transform.position).normalized;
						Quaternion lookRotation = Quaternion.LookRotation(direction);
						transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);	
					}
				}
			}
		}
	}
	
	void FixedUpdate() {
		rigidbody.AddForce(new Vector3(0, 0, inputForce));
	}
}
