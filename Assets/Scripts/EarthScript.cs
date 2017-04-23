using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthScript : MonoBehaviour {

	public float EarthRotationSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RotateEarth ();
	}

	private void RotateEarth()
	{
		transform.Rotate (0, EarthRotationSpeed * Time.deltaTime, 0);
	}
}
