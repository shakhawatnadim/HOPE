using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class IceMassAntarcticaPrediction : MonoBehaviour {

	private float rsquared;
	float yintercept;
	float slope;
	int[] month_day={0,31,28,31,30,31,30,31,31,30,31,30,31};

	private static IceMassAntarcticaPrediction instance;

	public static IceMassAntarcticaPrediction Instance
	{
		get{ 
			return instance;
		}
	}
	/*
		out float rsquared, out float yintercept,
		out float slope*/
	// Use this for initialization
	public void LinearRegression(float[] xVals, float[] yVals,
		int inclusiveStart, int exclusiveEnd)
	{
		Debug.Assert(xVals.Length == yVals.Length);
		float sumOfX = 0;
		float sumOfY = 0;
		float sumOfXSq = 0;
		float sumOfYSq = 0;
		float ssX = 0;
		float ssY = 0;
		float sumCodeviates = 0;
		float sCo = 0;
		float count = exclusiveEnd - inclusiveStart;

		for (int ctr = inclusiveStart; ctr < exclusiveEnd; ctr++)
		{
			float x = xVals[ctr];
			float y = yVals[ctr];
			sumCodeviates += x * y;
			sumOfX += x;
			sumOfY += y;
			sumOfXSq += x * x;
			sumOfYSq += y * y;
		}
		ssX = sumOfXSq - ((sumOfX * sumOfX) / count);
		ssY = sumOfYSq - ((sumOfY * sumOfY) / count);
		float RNumerator = (count * sumCodeviates) - (sumOfX * sumOfY);
		float RDenom = (count * sumOfXSq - (sumOfX * sumOfX))
			* (count * sumOfYSq - (sumOfY * sumOfY));
		sCo = sumCodeviates - ((sumOfX * sumOfY) / count);

		float meanX = sumOfX / count;
		float meanY = sumOfY / count;
		float dblR = RNumerator / Mathf.Sqrt(RDenom);

		rsquared = dblR * dblR;
		yintercept = meanY - ((sCo / ssX) * meanX);
		slope = sCo / ssX;
	}
	// Use this for initialization
	void Start () {
		instance = this;
		float[] yVal = new float[1000];
		float[] xVal=new float[1000];
		int i = 0;
		StreamReader sr= new StreamReader("IceDataAntarctica.txt");
		while (sr.Peek ()>=0) {
			string line = sr.ReadLine ();
			var parts=line.Split(' ');
			float a = Convert.ToSingle (parts[0]);
			//print (a);
			float b = Convert.ToSingle (parts[1]);
			xVal [i] = a;
			yVal [i] = b;
			print (a+" "+b);
			i++;
		}
		print (i);


		LinearRegression(xVal, yVal,0,i);
		//print( yintercept + (slope*yearDecimal));
	}

	public float getIcePredictionAntarctica(float y,float m, float d){
		float yearDecimal;
		int i;
		for(i=0;i<m-1;i++) d+=month_day[i];
		yearDecimal=y+(float)d/365.0f;
		if (yearDecimal < 2002)
			return 0;
		return yintercept + (slope * yearDecimal);
	}

	// Update is called once per frame
	void Update () {

	}
}
