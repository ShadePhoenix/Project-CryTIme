using UnityEngine;
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
		ContinuesText.text = "Continues: " + Continues;
		if (transform.gameObject.activeSelf) {
			if (time >= 0) {
				time = time - Time.deltaTime * 10000;
				Seconds.text = "" + Mathf.Round (time);
			} else {

			}

		}
	
	}

	public void Yes()
	{
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
		SceneManager.LoadScene ("Main Menu");
	}

}
