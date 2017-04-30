using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraceLaunchScript : MonoBehaviour {

	private Transform tr;
	public float speed = 5;
	public GameObject wayPoints;

	public GameObject part1, part2, part3, part4, part5, part6, TrailSmokeObj, NosePairObj;
	public Transform smokePoint1, smokePoint2, smokePoint3, smokePoint4;
	public GameObject[] path;

	public float HeavyBoosterReaseTime = 5f, Part3ReleaseTime = 30f , NosePairEjectTime = 20f;

	public int currentwayPointId;

	public float reachDistance = 1.0f;
	public float rotationSpeed = 5.0f;

	public float SpeedFactor = 1.5f;

	public float _time = -5;

	public Text T_cntdwn;

	Vector3 last_position;
	Vector3 current_position;
	// Use this for initialization
	void Start () {
		_time = -5;
		tr = GetComponent<Transform> ();
		//StartCoroutine (BreakIt ());
		last_position = transform.position;
		T_cntdwn.text = "T - " + Mathf.Floor (_time);
	}
	
	// Update is called once per frame
	void Update () {
		//T += Time.deltaTime;
		_time += Time.deltaTime;

		string ss = " T ";
		if (_time < 0)
			ss += Mathf.Floor (_time);
		else {
			ss += " + ";
			ss += Mathf.Floor (_time);
		}
		T_cntdwn.text = ss;
		if (_time < 0)
			return;
		
		
		LaunchGrace ();

		if (_time >= HeavyBoosterReaseTime) {
			part1.GetComponent<Rigidbody> ().isKinematic = false;
			part2.GetComponent<Rigidbody> ().isKinematic = false;
			part1.transform.parent = null;
			part2.transform.parent = null;
		}
		if( _time >= Part3ReleaseTime ){
			//Debug.Log (_time);
			part3.GetComponent<Rigidbody> ().isKinematic = false;
			TrailSmokeObj.transform.position = smokePoint2.position;
			part3.transform.parent = null;
		}
		if ( _time >= NosePairEjectTime ) {
			//Debug.Log (_time);
			NosePairObj.GetComponent<NosePairEjector>().EjectNow = true;
			NosePairObj.transform.parent = null;
		}

		if (_time > 0) {
			SpeedFactor += 0.01f * Mathf.Log10 (_time);
			//Debug.Log (SpeedFactor + "  " + _time);
			speed += SpeedFactor * Time.deltaTime;
		}


	}


	private void LaunchGrace()
	{
		Debug.Log ("Speed = " + speed);
		transform.Translate ( speed * transform.up * (-1) * Time.deltaTime );
		ApplySuperCurve ();
		ApplyLowCurve ();
		//tr.Translate (0, speed * Time.deltaTime, 0);
	}

	void ApplySuperCurve(){
		if ( 10 <=_time && _time <= 25  ) {
			Debug.Log ("Super Curving");
			transform.Rotate (new Vector3 (0, 1, 0), 3.5f * Time.deltaTime, Space.Self);
		}
	}

	void ApplyLowCurve(){
		if (25 <=_time && _time <= 35) {
			transform.Rotate (new Vector3 (0, 1, 0), 1 * Time.deltaTime, Space.Self);
		}
	}

	private IEnumerator BreakIt()
	{
		yield return new WaitForSeconds (HeavyBoosterReaseTime);
		part1.GetComponent<Rigidbody> ().isKinematic = false;
		part2.GetComponent<Rigidbody> ().isKinematic = false;
		part1.transform.parent = null;
		part2.transform.parent = null;

	}


	private void FollowPath()
	{
		float distane = Vector3.Distance (path [currentwayPointId].transform.position, transform.position);

		transform.position = Vector3.MoveTowards (transform.position, path [currentwayPointId].transform.position, speed * Time.deltaTime);

		var rotation = Quaternion.LookRotation (path [currentwayPointId].transform.position - transform.position);
		transform.rotation =  (Quaternion.Slerp(transform.rotation,rotation,Time.deltaTime*rotationSpeed));
		if (distane <= reachDistance) {
			currentwayPointId++;
		}
	}

}
