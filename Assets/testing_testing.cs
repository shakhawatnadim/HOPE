using UnityEngine;
using System.Collections;

public class testing_testing : MonoBehaviour {

	// Use this for initialization

	Vector2 conv_vector(Vector2 a,Vector2 b){

		float x, y;
		x = b.x - a.x;
		y = b.y - a.y;
		Vector2 v;
		v.x = x;
		v.y = y;
		return v;
	}
	void falling_angel(Vector2 a,Vector2 b){


		Vector2 v1 = conv_vector(b,a);
		Vector2 v2 = new Vector2 (-5.0f, 0.0f);
	//	v1 = new Vector2 (2, 2);
	//	v2 = new Vector2 (0, 3);
		float abs_v1 = (v1.x * v1.x) + (v1.y * v1.y);
		abs_v1 = Mathf.Sqrt (abs_v1);
		float abs_v2 = (v2.x * v2.x) + (v2.y * v2.y);
		abs_v2 = Mathf.Sqrt (abs_v2);
		float u_v = (v1.x * v2.x) + (v1.y * v2.y);
float angel = u_v / (abs_v1 * abs_v2);
		angel = Mathf.Acos (angel);
		angel = (angel * 180.0f) / Mathf.PI;
		Debug.Log (angel);	


	}
	void Start () {
		/*		float x = Mathf.Acos (0.70710678118f);
		x = (x * 180.0f) / Mathf.PI;
		Debug.Log (x);*/
		falling_angel (new Vector2 (0,5), new Vector2 (5,0));

	}
	// Update is called once per frame
	void Update () {
	
	}
}
