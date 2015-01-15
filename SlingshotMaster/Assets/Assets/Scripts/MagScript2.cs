using UnityEngine;
using System.Collections;

public class MagScript2 : MonoBehaviour {

	public float initV;
	public GameObject planets;
	public GameObject stateObject;
	public float forceMultiplier;

	private bool pos = true;

	// Use this for initialization
	void Start () {
		rigidbody.AddForce (initV * new Vector3(0,0,1));
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space) || Input.touches.Length > 0) {
			pos = !pos;
		}
		if (pos) {
			foreach (Transform planet in planets.transform) {
				PlanetScript ps =  planet.GetComponent<PlanetScript>();
				rigidbody.AddForce((ps.mass / ((planet.position - transform.position).magnitude)) *  
				                                       (planet.position - transform.position).normalized * Time.deltaTime * forceMultiplier);
				
				Debug.DrawLine(transform.position, transform.position + ((ps.mass / ((planet.position - transform.position).magnitude)) *  
				               (planet.position - transform.position).normalized * Time.deltaTime * forceMultiplier));
			}	
		}else{
			foreach (Transform planet in planets.transform) {
				PlanetScript ps =  planet.GetComponent<PlanetScript>();
				rigidbody.AddForce((ps.mass / ((planet.position - transform.position).magnitude)) *  -1 *
				                   (planet.position - transform.position).normalized * Time.deltaTime * forceMultiplier);
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Finish"){
			State.nextLevel();
		}else if(other.tag == "Planet"){
			State.restart();
		}else if(other.name == "Collectible"){
			stateObject.GetComponent<LevelScript>().Collect();
			GameObject.Destroy(other.gameObject);
		}
	}

	void OnTriggerExit(Collider other){
		if(other.name == "Bounds"){
			State.outOfBounds();
		}
	}
}
