using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

	public Text countdown;
	public float count = 60;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		count = count - Time.deltaTime;
		countdown.text = "" + Mathf.Round(count);
		if (count <= 15) {
			countdown.color = Color.red;
		}
	
	}
}
