using UnityEngine;
using System.Collections;

public class SplashCamera : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (transform.position.x > 60)
						transform.position -= new Vector3 (1, 0, 0) * Time.deltaTime;
		}
}
