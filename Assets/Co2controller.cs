using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class Co2controller : MonoBehaviour {

	public Image co2;
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

		height =  co2.color.a;
	}

	// Update is called once per frame
	void Update () {

	}

	void getDataFromFile(){

		int i = 0;
		StreamReader sr= new StreamReader("Co2Data.txt");
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
		float y = Co2CanvasController.Instance.PredictButtonPressed ();
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
		sealevel.text = "Amount of CO2: " +yVal[0] +" mm";
		co2.color =  new Vector4(co2.color.r,co2.color.g,co2.color.b,0);
		yield return new WaitForSeconds (4);
		co2.color =  new Vector4(co2.color.r,co2.color.g,co2.color.b,1);

		year.text = "Year: " +xVal[100];
		sealevel.text = "Amount of CO2: " + yVal[100] +" ppm";

		yield return new WaitForSeconds (2);
		co2.color =  new Vector4(co2.color.r,co2.color.g,co2.color.b,3);
		year.text = "Year: " +xVal[200];
		sealevel.text = "Amount of CO2: " +yVal[200] +" ppm";
		yield return new WaitForSeconds (2);
		co2.color =  new Vector4(co2.color.r,co2.color.g,co2.color.b,4);
		year.text = "Year: " +xVal[300];
		sealevel.text = "Amount of CO2: " +yVal[300]+" ppm";
		yield return new WaitForSeconds (2);
		co2.color =  new Vector4(co2.color.r,co2.color.g,co2.color.b,5);
		year.text = "Year: " +xVal[400];
		sealevel.text = "Amount of CO2: " + yVal [400] + " ppm";

		yield return new WaitForSeconds(6);
		mainPanel.SetActive(true);
		ShowPanel.SetActive(false);



		co2.color= new Vector4(co2.color.r,co2.color.g,co2.color.b,height);



	}

	public void predBack()
	{
		PredictPanle.SetActive (false);
		mainPanel.SetActive (true);
	}
}
