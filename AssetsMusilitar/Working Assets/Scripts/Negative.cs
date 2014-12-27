using UnityEngine;
using System.Collections;

public class Negative : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay(Collider collider) {
		Debug.Log("Object entered magnetic field of negative");
		Debug.Log("Triggered by " + collider.gameObject.tag);
		if(collider.gameObject.tag == "Negative") {
			Debug.Log("Pushing away");
			collider.transform.parent.rigidbody.AddForce(Camera.main.transform.right * 10);
			collider.transform.parent.rigidbody.AddForce(Camera.main.transform.up * 10);
		}
		if(collider.gameObject.tag == "Positive") {
			Debug.Log("Pulling closer");
			collider.transform.parent.rigidbody.AddForce(Camera.main.transform.right * -10);
			collider.transform.parent.rigidbody.AddForce(Camera.main.transform.up * -10);
		}
	}
}
