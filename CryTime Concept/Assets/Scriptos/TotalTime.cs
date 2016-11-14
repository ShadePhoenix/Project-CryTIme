using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TotalTime : MonoBehaviour {

	public float timer;
	public Text timertext;
	int minute;

	public bool counting = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (counting) {
			timer = timer + Time.deltaTime;
			timertext.text = minute + ":" + Mathf.Round (timer * 100f) / 100f;
			if (timer >= 60) {
				timer = 0;
				minute++;
			}
	
		}
	}
}
