using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	public Vector3 offset;
	public Transform target;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime);
	}
}

