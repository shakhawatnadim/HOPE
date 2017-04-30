using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NosePairEjector : MonoBehaviour {

	// Use this for initialization
	public bool EjectNow;
	public float ApartSpeed = 5;
	public GameObject NosePart1, NosePart2;
	Vector3 v = new Vector3(0, 1, 0);
	void Start () {
		EjectNow = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (EjectNow) {
			NosePart1.transform.Translate (v * Time.deltaTime * ApartSpeed);
			NosePart2.transform.Translate (v * Time.deltaTime * ApartSpeed);
		}
	}
}
