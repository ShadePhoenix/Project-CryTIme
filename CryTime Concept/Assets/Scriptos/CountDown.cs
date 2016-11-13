﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

	public Text countdown;
	public float count = 60;
	public GameObject player;
	public GameObject GO;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (count <= 15) {
			countdown.color = Color.red;
		} else {
			countdown.color = Color.green;
		}

		if (count > 59) {
			count = 59;
		}

		if (count > 0) {
			count = count - Time.deltaTime;
			countdown.text = "" + Mathf.Round (count);

		} else {
			GO.SetActive (true);
			Time.timeScale = 0.0001f;
			player.GetComponent<Playerhit> ().GameOver = true;
		}
	
	}
}
