using UnityEngine;
using System.Collections;
using System;
using System.IO;


public class WriteSeaLevelData : MonoBehaviour {
	int[] month_day={0,31,28,31,30,31,30,31,31,30,31,30,31};

	private static WriteSeaLevelData instance;

	public static WriteSeaLevelData Instance
	{
		get{ 
			return instance;
		}
	}

	// Use this for initialization
	void Start () {
		instance = this;
		//float f1=23.45f;
		//float f2=45.67f;
		//putData()

	}
	public void putData(float year,float month,float day,float gsml_variation){
		float predict = SeaLevelPrediction.Instance.getSeaLevelPrediction (year, month, day);
		float yearDecimal=getDecimalDate(year,month,day);
		//int i;
		//for(i=0;i<month-1;i++) day+=month_day[i];
		//yearDecimal=year+(float)day/365.0f;
		if (isReliable (yearDecimal, gsml_variation, predict)) {
			string str1 = yearDecimal.ToString ();
			string str2 = gsml_variation.ToString ();
			using (FileStream fs = new FileStream ("gsml_data.txt", FileMode.Append, FileAccess.Write))
			using (StreamWriter sw = new StreamWriter (fs)) {
				string line = str1 + " " + str2;
				sw.WriteLine (line);
			}
		} else {
			print ("Not reliable Data");
		}
	}

	public float getDecimalDate(float year,float month,float day){
		float decimal_date;
		int i;
		for(i=0;i<month-1;i++) day+=month_day[i];
		decimal_date=year+(float)day/365.0f;
		return decimal_date;
	}
	public bool isReliable(float Dyear, float gsml_variation,float predict){
		float diff = predict - gsml_variation;
		if (Mathf.Abs (diff) > 10.0f)
			return false;
		else
			return true;

	}

	// Update is called once per frame
	void Update () {

	}
}
