using UnityEngine;
using System.Collections;
using System.IO;
using System;


public class FileInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print ("infileinput");
			StreamReader sr = new StreamReader("input.txt");
            
			print("ahkl;");
	        // Read the stream to a string, and write the string to the console.
			 while (sr.Peek() >= 0) 
                {
					string line = sr.ReadLine();
                    print(line);
										//string str = "10 12";
					var parts = line.Split(' ');
					float a = Convert.ToSingle(parts[0]);
					float b = Convert.ToSingle(parts[1]);


                }
                //String line = sr.ReadToEnd();
                //Console.WriteLine(line);
			print("ahkl;");
        /*}
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }*/
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
