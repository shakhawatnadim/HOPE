using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	[SerializeField] public float xMax;
	[SerializeField] private float yMax;
	[SerializeField] public float xMin;
	[SerializeField] private float yMin;
	[SerializeField]  Vector3 Leftpoint;

	public float thresHold;

	private Transform target;

	private float right;

	public bool BattleCam;
	/*


	// Use this for initialization
	void Start () {

		target = GameObject.Find ("Player").transform;

		thresHold = transform.position.x - Leftpoint.x;
//		Debug.Log (thresHold.ToString ());
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		if (!BattleCam) {
			Leftpoint = GameObject.FindGameObjectWithTag ("LeftEnd").transform.position;
			xMin = Leftpoint.x - thresHold;

			right = target.transform.position.x + 40;

			if (xMax < right)
				xMax += 10* Time.deltaTime;

		}

		transform.position = new Vector3(Mathf.Clamp (target.position.x, xMin, xMax), Mathf.Clamp (target.position.y, yMin, yMax),transform.position.z);

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			col.transform.GetComponent<PlayerController> ().hor = 0;
		}
	}
	*/

//	void CollisionEnter2D(Collider2D col)
//	{
//		Debug.Log (col.gameObject.name);
//	}
}
