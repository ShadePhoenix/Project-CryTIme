﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour {

	public Text Seconds;
	public int Continues = 3;
	public Text ContinuesText;
	public GameObject player;
	public CountDown Overalltime;

	float time = 10;

	// Use this for initialization
	void Start () {

		//this.gameObject.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		//this shows a 10 second down in the game over screen
		ContinuesText.text = "Continues: " + Continues;
		if (transform.gameObject.activeSelf) {
			if (time >= 0) {
				time = time - Time.deltaTime * 10000;
				Seconds.text = "" + Mathf.Round (time);
			} 

		}
	
	}

	public void Yes()
	{
		//this is a function that goes on a button, when it's pressed, itll continue the game
		if (Continues > 0) {
			Time.timeScale = 1;
			Continues = Continues - 1;
			player.GetComponent<Playerhit> ().Continue ();
			gameObject.SetActive (false);
			time = 10;
			Overalltime.count = 59;
		}
	}

	public void No()
	{
		//if clicked, it changes the scene to the main menu
		SceneManager.LoadScene ("Main Menu");
	}

}
