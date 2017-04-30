using UnityEngine;
using System.Collections;
using System;
using System.IO;


public class WriteIceGreemland : MonoBehaviour {
	int[] month_day={0,31,28,31,30,31,30,31,31,30,31,30,31};

	private static WriteIceGreemland instance;

	public static WriteIceGreemland Instance
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
	public void putData(float year,float month,float day,float mass){
		float pdict = Co2Prediction.Instance.getCo2Prediction (year, month, day);

		float yearDecimal = getDecimalDate (year,month,day);
		//int i;
		//for(i=0;i<month-1;i++) day+=month_day[i];
		//yearDecimal=year+(float)day/365.0f;
		string str1=yearDecimal.ToString();
		string str2=mass.ToString();
		using (FileStream fs = new FileStream("IceDataGreenland.txt",FileMode.Append, FileAccess.Write))
		using (StreamWriter sw = new StreamWriter(fs))
		{
			string line=str1+" "+str2;
			sw.WriteLine(line);
		}
	}
	public float getDecimalDate(float year,float month,float day){
		float decimal_date;
		int i;
		for(i=0;i<month-1;i++) day+=month_day[i];
		decimal_date=year+(float)day/365.0f;
		return decimal_date;
	}

	// Update is called once per frame
	void Update () {

	}
}
