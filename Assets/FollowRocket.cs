using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRocket : MonoBehaviour {

	public GameObject Rocket;
	public float offSetX = 0, offSetY = 0;
	Vector3 RocketCamDistVector;
	// Use this for initialization
	void Start () {
		RocketCamDistVector = transform.position - Rocket.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Rocket.transform.position + RocketCamDistVector;
		//Debug.Log (RocketCamDistVector);
	}
}
