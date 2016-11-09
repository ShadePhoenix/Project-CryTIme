using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class AddTime : MonoBehaviour {

	[Serializable]
	public class Stage
	{
		public GameObject[] objects;
		public int time;
		public bool com;
		public bool done;
	}

	public Stage[] stages;

	public CountDown time;
	public RawImage Extended;


	// Use this for initialization
	void Start () {

	}

	IEnumerator Extend()
	{
		Extended.gameObject.SetActive (true);
		yield return new WaitForSeconds (1);
		Extended.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		foreach (Stage obj in stages) {
			if (!obj.done) {
				foreach (GameObject enemy in obj.objects) {
					if (enemy.activeSelf) {
						obj.com = false;
						break;
					} else {
						obj.com = true;
					}
				}
			}
		}
		foreach (Stage obj in stages) {
			if (obj.com) {
				obj.done = true;
				obj.com = false;
				time.count = time.count + obj.time;
				StartCoroutine (Extend ());
			}
		}
	
	}
}
