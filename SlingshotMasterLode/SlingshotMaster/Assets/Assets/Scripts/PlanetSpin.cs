using UnityEngine;
using System.Collections;

public class PlanetSpin : MonoBehaviour {

	private int speedUP;
	private int speedRight;
	

	// Use this for initialization
	void Start () {
		speedUP = Random.Range(10, 20);
		speedRight = Random.Range(10, 20);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up, speedUP * Time.deltaTime);
		transform.Rotate(Vector3.right, speedRight * Time.deltaTime);
	}
}