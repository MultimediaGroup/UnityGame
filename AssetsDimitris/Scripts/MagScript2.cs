using UnityEngine;
using System.Collections;

public class MagScript2 : MonoBehaviour {

	public float initV;
	public GameObject planets;

	private bool pos = true;

	// Use this for initialization
	void Start () {
		rigidbody.AddForce (initV * new Vector3(0,0,1));
	}
	
	// Update is called once per frame
	void Update () {
		if (/*Input.GetKey (KeyCode.Space) ||*/ Input.touches.Length > 0) {
			pos = !pos;
		}

		if (pos) {
			foreach (Transform planet in planets.transform) {
				PlanetScript ps =  planet.GetComponent<PlanetScript>();
				rigidbody.AddForce(ps.mass / (planet.position - transform.position).magnitude * (planet.position - transform.position).normalized * Time.deltaTime);
			}	
		}else{
			foreach (Transform planet in planets.transform) {
				PlanetScript ps =  planet.GetComponent<PlanetScript>();
				rigidbody.AddForce(ps.mass / (planet.position - transform.position).magnitude * -1 * (planet.position - transform.position).normalized * Time.deltaTime);
			}
		}
	}
}
