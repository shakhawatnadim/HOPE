using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	private GameObject EarthCenter;
	public float GraceRotationSpeed;
	private GameObject Earth;
	public float EarthRotationSpeed;

	// Use this for initialization
	void Start () {
		EarthCenter = GameObject.Find ("EarthCenter");
		Earth = GameObject.Find ("earth");
	}
	
	// Update is called once per frame
	void Update () {
		RotateGrace ();
		RotateEarth ();
	}

	private void RotateEarth()
	{
		Earth.transform.Rotate (0, EarthRotationSpeed * Time.deltaTime, 0);
	}

	private void RotateGrace()
	{
		EarthCenter.transform.Rotate (GraceRotationSpeed * Time.deltaTime, 0, 0);
	}


}
