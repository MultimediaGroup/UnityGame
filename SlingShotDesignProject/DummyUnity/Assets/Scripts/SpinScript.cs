using UnityEngine;
using System.Collections;

public class SpinScript : MonoBehaviour {

	public int min = 10;
	public int max = 20;
	public bool left = false;

	private int speedVertical;
	private int speedHorizontal;
	

	// Use this for initialization
	void Start () {
		speedVertical = Random.Range(5, 10);
		speedHorizontal = Random.Range(5, 10);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up, speedVertical * Time.deltaTime);
		if (left) transform.Rotate(Vector3.left, speedHorizontal * Time.deltaTime);
		else transform.Rotate(Vector3.right, speedHorizontal * Time.deltaTime);
	}
}