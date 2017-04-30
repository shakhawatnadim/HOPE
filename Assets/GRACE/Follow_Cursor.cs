using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Cursor : MonoBehaviour {

	public bool ShowCursor;
	public float Sensitivity;

	void Start(){

		if(ShowCursor == false)
		{
			Cursor.visible=false;
		}
	}



	void Update(){

		float newRotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X")* Sensitivity;
			float newRotationX = transform.localEulerAngles.x + Input.GetAxis("Mouse Y")* Sensitivity;
			gameObject.transform.localEulerAngles = new Vector3(newRotationX,newRotationY,0);
	}


}