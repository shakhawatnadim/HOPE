using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SatelliteInfoScripts : MonoBehaviour {

	public string[] headings;
	public string[] Descriptions;
	public AudioSource[] audios;

	public float showSpeed;
	public Sprite[] SoundSprite;

	 private GameObject Grace, Aqua, terra;
	 private Vector3 GraceDefaultTransform, AquaDefaultTransform, TerraDefaultTransform;
	private GameObject GraceMore, AquaMore, TerraMore;
	private GameObject soundButton;


	private IEnumerator coroutine;
	private bool sound; 


	public Text ShowHeading, ShowDexcription;
	// Use this for initialization
	void Start () {
		sound = true;
		Grace = GameObject.Find ("Grace");
		Aqua = GameObject.Find ("Aqua");
		terra = GameObject.Find ("Terra");
		GraceMore = GameObject.Find ("GraceMore");
		AquaMore = GameObject.Find ("AquaMore");
		TerraMore = GameObject.Find ("TerraMore");
		soundButton = GameObject.Find ("SoundButton");
		GraceDefaultTransform = Grace.GetComponent<Transform>().eulerAngles;
		TerraDefaultTransform = Aqua.GetComponent<Transform>().eulerAngles;
		AquaDefaultTransform = (Vector3) Aqua.transform.eulerAngles;
		Aqua.SetActive (false);
		terra.SetActive (false);
		AquaMore.SetActive (false);
		TerraMore.SetActive (false);

		coroutine =	Show(Descriptions[0],headings[0]);
		StartCoroutine (coroutine);


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Show(string des,string head)
	{
		int len = des.Length;
		ShowHeading.text = head;
		int currentIndex = 0;
		ShowDexcription.text = "";

		while (currentIndex < len) {
			ShowDexcription.text += des[currentIndex];
			currentIndex++;
		
			if (currentIndex < len)
				yield return new WaitForSeconds (showSpeed);
			else
				break;
		}
	}

	public void GracePressed()
	{
		if (!Grace.activeInHierarchy) {
			StopCoroutine (coroutine);
			Grace.SetActive (true);
			GraceMore.SetActive (true);
			Grace.gameObject.transform.rotation = Quaternion.Euler( GraceDefaultTransform);
			Aqua.SetActive (false);
			terra.SetActive (false);
			PlaySound (0);
			coroutine = Show (Descriptions [0], headings [0]);
			StartCoroutine (coroutine);
		}
	}

	public void AquaPressed()
	{
		if (!Aqua.activeInHierarchy) {
			
			StopCoroutine (coroutine);
		
			Aqua.SetActive (true);
			AquaMore.SetActive (true);
			Aqua.gameObject.transform.rotation = Quaternion.Euler(AquaDefaultTransform);
			Grace.SetActive (false);
			terra.SetActive (false);
			PlaySound (1);
			coroutine = Show (Descriptions [1], headings [1]);
			StartCoroutine (coroutine);
		}
			
	}
	public void TerraPressed()
	{
		if (!terra.activeInHierarchy) {

			StopCoroutine (coroutine);
	
			terra.SetActive (true);
			TerraMore.SetActive (true);
			Aqua.gameObject.transform.rotation = Quaternion.Euler(AquaDefaultTransform);
			Grace.SetActive (false);
			Aqua.SetActive (false);
			PlaySound (2);
			coroutine = Show (Descriptions [2], headings [2]);
			StartCoroutine (coroutine);
		}

	}

	public void GraceMorePressed()
	{
		StopCoroutine (coroutine);
		PlaySound (3);
		coroutine = Show (Descriptions [3], headings [3]);
		StartCoroutine (coroutine);
	}

	public void AquaMorePressed()
	{
		StopCoroutine (coroutine);
		PlaySound (4);
		coroutine = Show (Descriptions [4], headings [4]);
		StartCoroutine (coroutine);
	}
	public void TerraMorePressed()
	{
		StopCoroutine (coroutine);
		PlaySound (5);
		coroutine = Show (Descriptions [5], headings [5]);
		StartCoroutine (coroutine);
	}

	void PlaySound (int indx)
	{
		for(int i=0  ; i<audios.Length ; i++)
		{
			audios [i].Stop ();
		}
		audios [indx].Play ();
	}

	public void SoundButtonPressed()
	{
		if (sound) {
			for (int i = 0; i < audios.Length; i++) {
				audios [i].Stop ();
				sound = false;
				soundButton.GetComponent<Image> ().sprite = SoundSprite [1];
			}
		}
		else {
			sound = true;
			soundButton.GetComponent<Image> ().sprite = SoundSprite [0];
		}
		
	}

}
