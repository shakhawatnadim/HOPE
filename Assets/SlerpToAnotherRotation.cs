using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlerpToAnotherRotation : MonoBehaviour {

	// Use this for initialization

	public Transform target, own;
	public float RotSpeed = 0.1f;
	Quaternion q_own;
	void Start () {
		q_own = new Quaternion(own.rotation.x, own.rotation.y, own.rotation.z, own.rotation.w);
	}
	
	// Update is called once per frame
	void Update () {
		RotSpeed += Time.deltaTime;
		transform.rotation = Quaternion.Lerp ( q_own, target.rotation, RotSpeed * Time.deltaTime );
	}
}
