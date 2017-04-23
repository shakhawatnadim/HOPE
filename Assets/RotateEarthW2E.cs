using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEarthW2E : MonoBehaviour {

	// Use this for initialization
	float EarthRotationSpeed = 10;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 rt = new Vector3 (0, 1, 0);
		transform.Rotate (rt * Time.deltaTime * EarthRotationSpeed , Space.Self);
	}
}
