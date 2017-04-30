using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SeaCanvasControl : MonoBehaviour {

	public InputField yearField, monthField, dayField;
	public float year, month, day;



	private static SeaCanvasControl instance;

	public static SeaCanvasControl Instance
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
		float pdict = SeaLevelPrediction.Instance.getSeaLevelPrediction (year, month, day);

		return pdict;
	}
}
