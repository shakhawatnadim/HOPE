using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour {

	// Use this for initialization
	public GameObject cam1, cam2, cam3, cam4;
	void Awake () {
		Cam4Pressed ();
	}
	void Start() {
		Cam4Pressed ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Cam1Pressed(){
		cam1.SetActive (true);
		cam2.SetActive (false);
		cam3.SetActive (false);
		cam4.SetActive (false);
	}

	public void Cam2Pressed(){
		cam1.SetActive (false);
		cam2.SetActive (true);
		cam3.SetActive (false);
		cam4.SetActive (false);
	}

	public void Cam3Pressed(){
		cam1.SetActive (false);
		cam2.SetActive (false);
		cam3.SetActive (true);
		cam4.SetActive (false);
	}

	public void Cam4Pressed(){
		cam1.SetActive (false);
		cam2.SetActive (false);
		cam3.SetActive (false);
		cam4.SetActive (true);
	}
}
