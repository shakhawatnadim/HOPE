
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Co2CanvasController : MonoBehaviour {

	public InputField yearField, monthField, dayField;
	public float year, month, day;



	private static Co2CanvasController instance;

	public static Co2CanvasController Instance
	{
		get{ 
			return instance;
		}
	}



	// Use this for initialization
	void Start () {
		instance = this;
	}

	// Update is called once per frame
	void Update () {
		instance = this;
	}

	public void YearValuchange(string value)
	{
		year = float.Parse (value);
	}

	public void MonthValuchange(string value)
	{
		month = float.Parse (value);
	}

	public void DayValuchange(string value)
	{
		day = float.Parse (value);
	}

	public float PredictButtonPressed()
	{
		float pdict = Co2Prediction.Instance.getCo2Prediction (year, month, day);

		return pdict;
	}
}

