using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GracePairBalance : MonoBehaviour {

	// Use this for initialization
	public GameObject go_gp1, go_gp2;
	public Transform earthCenter;
	public float force = 5f;
	public int g_change_interval = 5;
	float emit;
	int sign = 1;
	Vector3 move;
	void Start () {
		move = new Vector3 (0, 0, 1);
		emit = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		emit += Time.deltaTime;
		go_gp1.transform.Translate ( move * force * Time.deltaTime * sign * (1) );
		go_gp2.transform.Translate ( move * force * Time.deltaTime * sign * (-1) );

		/*if (emit >= g_change_interval) {
			emit = 0f;
			move *= -1;
			//Debug.Log (move);
		}*/

		Debug.Log (earthCenter.position.y + "  " + transform.position.y);

		if (Mathf.Abs (earthCenter.position.y - transform.position.y) <= (5) ) {
			if (sign > 0)
				sign = -1;
			//Debug.Log ("Equator");
		}
		if (Mathf.Abs (earthCenter.position.z - transform.position.z) <= (5) ) {
			if (sign < 0)
				sign = 1;
			//Debug.Log ("Pole");
		}

		/*if (Mathf.Abs (earthCenter.position.y - transform.position.y) <= (1e-6) && (earthCenter.position.z - transform.position.z) < 0) {
			if (sign > 0)
				sign = -1;
		}
		if (Mathf.Abs (earthCenter.position.z - transform.position.z) <= (1e-6) && (earthCenter.position.y - transform.position.y) < 0) {
			if (sign < 0)
				sign = 1;
		}*/
	}
}
