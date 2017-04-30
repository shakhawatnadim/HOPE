using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class SeaController : MonoBehaviour {

	public GameObject seawater;
	float[] yVal = new float[1000];
	float[] xVal=new float[1000];

	public GameObject mainPanel, PredictPanle, ShowPanel;
	private float height;
	public Text year, sealevel, Predicted;

	// Use this for initialization
	void Start () {
		getDataFromFile ();
		PredictPanle.SetActive (false);
		ShowPanel.SetActive (false);

		height = seawater.transform.position.y;
	}

	// Update is called once per frame
	void Update () {

	}

	void getDataFromFile(){

		int i = 0;
		StreamReader sr= new StreamReader("gsml_data.txt");
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
		float y = SeaCanvasControl.Instance.PredictButtonPressed ();
		Predicted.text = "Rise in sea level from 1993: " + y + " mm";
	}

	public void Visualize()
	{
		mainPanel.SetActive (false);
		ShowPanel.SetActive (true);
		StartCoroutine (Drown ());
	}

	IEnumerator Drown()
	{
		year.text = "Year: " +xVal[0];
		sealevel.text = "Sea level: " +yVal[0] +" mm";

		yield return new WaitForSeconds (4);
		seawater.gameObject.transform.position = new Vector3(seawater.transform.position.x, seawater.transform.position.y+.4f, seawater.transform.position.z);

		year.text = "Year: " +xVal[222];
		sealevel.text = "Sea level rise: " +( yVal[222]- yVal[0]) +" mm";

		yield return new WaitForSeconds (2);
		seawater.transform.position = new Vector3(seawater.transform.position.x, seawater.transform.position.y+.8f, seawater.transform.position.z);
		year.text = "Year: " +xVal[444];
		sealevel.text = "Sea level rise: " +( yVal[444]- yVal[0]) +" mm";
		yield return new WaitForSeconds (2);
		seawater.transform.position = new Vector3(seawater.transform.position.x, seawater.transform.position.y+.12f, seawater.transform.position.z);
		year.text = "Year: " +xVal[666];
		sealevel.text = "Sea level rise: " +(yVal[666]- yVal[0]) +" mm";
		yield return new WaitForSeconds (2);
		seawater.transform.position = new Vector3(seawater.transform.position.x, seawater.transform.position.y+.16f, seawater.transform.position.z);
		year.text = "Year: " +xVal[886];
		sealevel.text = "Sea level rise: " + (yVal [886] - yVal [0]) + " mm";

		yield return new WaitForSeconds(6);
		mainPanel.SetActive(true);
		ShowPanel.SetActive(false);


			
		seawater.transform.position = new Vector3 (seawater.transform.position.x, height, seawater.transform.position.z);
		


	}

	public void predBack()
	{
		PredictPanle.SetActive (false);
		mainPanel.SetActive (true);
	}
}
