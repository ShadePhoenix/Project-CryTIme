﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Admin : MonoBehaviour {

	public GameObject[] Enemies;
	public Text admin;
	public float SkipDistance;

	bool wave1over = false;
	bool wave2over = false;
	bool wave3over = false;

	// Use this for initialization
	void Start () {
		admin.gameObject.SetActive (true);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Insert)) {
			foreach (GameObject enemy in Enemies) {
				float dist = Vector3.Distance (transform.position, enemy.transform.position);
				if (dist <= SkipDistance) {
					enemy.gameObject.SetActive(false);
				}
			}
		}
	
	}
}
