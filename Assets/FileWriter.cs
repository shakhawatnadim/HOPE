using UnityEngine;
using System.Collections;
using System;
using System.IO;


public class FileWriter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float f1=23.45f;
		float f2=45.67f;
		string str1=f1.ToString();
		string str2=f2.ToString();
		using (FileStream fs = new FileStream("input.txt",FileMode.Append, FileAccess.Write))
		 using (StreamWriter sw = new StreamWriter(fs))
		 {
			 string line=str1+" "+str2;
			sw.WriteLine(line);
		 }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
