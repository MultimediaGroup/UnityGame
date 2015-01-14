using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {

	public GameObject planet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(planet.transform.position, Vector3.up, 20 * Time.deltaTime);
	}
}
