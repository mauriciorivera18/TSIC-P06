using UnityEngine;
using System.Collections;

// PLEASE NOTE! THIS SCRIPT IS FOR DEMO PURPOSES ONLY :) //

public class Plane : MonoBehaviour {
	public GameObject prop;

	public bool engenOn;

	void Update () 
	{
		if (engenOn) {
			prop.transform.Rotate (500 * Time.deltaTime, 0, 0);
		}
	}
}

// PLEASE NOTE! THIS SCRIPT IS FOR DEMO PURPOSES ONLY :) //