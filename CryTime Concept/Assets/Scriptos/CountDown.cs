using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

	public Text countdown;
	public float count = 60;
	public GameObject player;
	public GameObject GO;

	public bool counting = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (counting) {
			//if the counter is = or below 15, it sets the colour to red
			if (count <= 15) {
				countdown.color = Color.red;
			} else {
				countdown.color = Color.green;
			}

			if (count > 59) {
				count = 59;
			}
			//a simple counter that counts up
			if (count > 0) {
				count = count - Time.deltaTime;
				countdown.text = "" + Mathf.Round (count);

			} else {
				GO.SetActive (true);
				//the reason for setting the timescale to .0001 is so that there can be a counter in the game over screen
				Time.timeScale = 0.0001f;
				player.GetComponent<Playerhit> ().GameOver = true;
			}
	
		}
	}
}
