using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class IceController : MonoBehaviour {

	public GameObject[] Stones;
	float[] yVal = new float[1000];
	float[] xVal=new float[1000];

	public GameObject mainPanel, PredictPanle, ShowPanel;
	private float [] height = new float[4];
	public Text year, iceLevel, Predicted;

	// Use this for initialization
	void Start () {
		getDataFromFile ();
		PredictPanle.SetActive (false);
		ShowPanel.SetActive (false);
		for (int i = 0; i < Stones.Length; i++)
			height [i] = Stones [i].transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void getDataFromFile(){
		
		int i = 0;
		StreamReader sr= new StreamReader("IceDataGreenland.txt");
		while (sr.Peek ()>=0) {
			string line = sr.ReadLine ();
			var parts=line.Split(' ');
			float a = Convert.ToSingle (parts[0]);
			//print (a);
			float b = Convert.ToSingle (parts[1]);
			xVal [i] = a;
			yVal [i] = b;
			i++;
		}
	}
	public void PredictPressed()
	{
		mainPanel.SetActive (false);
		PredictPanle.SetActive(true);
		Predicted.text = "";

	}

	public void Pred()
	{
		float y = CanvasControls.Instance.PredictButtonPressed ();
		Predicted.text = "Reduced mass of ice: " + y + " GT";
	}

	public void Visualize()
	{
		mainPanel.SetActive (false);
		ShowPanel.SetActive (true);
		StartCoroutine (Drown ());
	}

	IEnumerator Drown()
	{
		for (int i = 0; i < Stones.Length; i++)
			Stones [i].transform.position = new Vector3 (Stones [i].transform.position.x, height [i], Stones [i].transform.position.z);


		year.text = "Year: " +xVal[0];
		iceLevel.text = "Mass of ice: " +yVal[0] +"GT";

		yield return new WaitForSeconds (4);
		Stones [0].GetComponent<Rigidbody> ().isKinematic = false;

		year.text = "Year: " +xVal[37];
		iceLevel.text = "Reduced mass of ice: " +( yVal[0]- yVal[37]) +"GT";

		yield return new WaitForSeconds (2);
		Stones [1].GetComponent<Rigidbody> ().isKinematic = false;
		year.text = "Year: " +xVal[74];
		iceLevel.text = "Reduced mass of ice: " +( yVal[0]- yVal[74]) +"GT";
		yield return new WaitForSeconds (2);
		Stones [2].GetComponent<Rigidbody> ().isKinematic = false;
		year.text = "Year: " +xVal[112];
		iceLevel.text = "Reduced mass of ice: " +(yVal[0]- yVal[112]) +"GT";
		yield return new WaitForSeconds (2);
		Stones [3].GetComponent<Rigidbody> ().isKinematic = false;
		year.text = "Year: " +xVal[151];
		iceLevel.text = "Reduced mass of ice: " +(yVal[0]- yVal[151]) +"GT";

		yield return new WaitForSeconds(6);
		mainPanel.SetActive(true);
		ShowPanel.SetActive(false);

		for (int i = 0; i < Stones.Length; i++)
		{
			Stones[i].GetComponent<Rigidbody>().isKinematic = true;
			Stones [i].transform.position = new Vector3 (Stones [i].transform.position.x, height [i], Stones [i].transform.position.z);
		}
			

	}

	public void predBack()
	{
		PredictPanle.SetActive (false);
		mainPanel.SetActive (true);
	}
}
