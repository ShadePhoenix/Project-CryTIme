using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Accuracy : MonoBehaviour {


	public TotalTime ttime;
	public int ShotsFired;
	public int ShotsHit;
	public Text AccuracyText;
	public Text TotalAccuracyText;
	public Text TotalTime;
	public Text StageNumber;
	public GameObject player;
	public Text TicketsEarned;
	public float Tickets;
	float timer;
	int minute;

	public Text WholeTime;
	public Text WholeAcc;
	public Text WholeShots;
	public Text WholeTickets;

	public int Stage1ShotsFired = 0;
	public int Stage1ShotsHit = 0;
	public int Stage2ShotsFired = 0;
	public int Stage2ShotsHit = 0;
	public int Stage3ShotsFired = 0;
	public int Stage3ShotsHit = 0;
	public int TotalShotsFired = 0;
	public int TotalShotsHit = 0;

	public GameObject StageResults;
	public GameObject FinalResults;

	public float AccuracyPercent;
	int StageNum = 1;
	bool stagecom = true;
	bool stagecom2 = true;
	bool stagecom3 = true;

	// Use this for initialization
	void Start () {
	}

	IEnumerator FinalStageScreen()
	{
		TotalShotsHit = Stage1ShotsHit + Stage2ShotsHit + Stage3ShotsHit;
		TotalShotsFired = Stage1ShotsFired + Stage2ShotsFired + Stage3ShotsFired;
		WholeShots.text = "(" + TotalShotsHit + "/" + TotalShotsFired + ")";
		float totalAcc = (float)TotalShotsHit / (float)TotalShotsFired;
		WholeAcc.text = "" + totalAcc * 100;
		WholeTime.text = "" + ttime.timertext;
		Tickets = 200 * totalAcc;
		Mathf.Round (Tickets);
		int t = PlayerPrefs.GetInt("TotalTicket");
		t += (int)Tickets;
		PlayerPrefs.SetInt ("TotalTicket", t);
		WholeTickets.text = "" + Mathf.Round (Tickets);
		FinalResults.SetActive (true);
		yield return new WaitForSeconds (5);
		SceneManager.LoadScene ("Main Menu");

	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag ("CutScene3")) {
			StartCoroutine (FinalStageScreen ());
			Time.timeScale = 0;
		}


		timer = timer + Time.deltaTime;
		if (timer >= 60) {
			timer = 0;
			minute++;
		}

		if (player.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag ("StageComplete1") && stagecom) {
			stagecom = false;
			StartCoroutine (showui ());
		} 
		if (player.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag ("StageComplete2") && stagecom2) {
			stagecom2 = false;
			StartCoroutine (showui ());
		} 
		if (player.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag ("StageComplete3") && stagecom3) {
			stagecom3 = false;
			StartCoroutine (showui ());
		} 

		//Tickets = 50 * AccuracyPercent;
		TicketsEarned.text = "" + Mathf.Round (Tickets);
		TotalTime.text =  minute + ":" + Mathf.Round(timer * 100f) / 100f;
		StageNumber.text = "" + StageNum;
		AccuracyText.text = "(" + ShotsHit + "/" + ShotsFired + ")";
		Mathf.Round (AccuracyPercent);
		TotalAccuracyText.text = "" + AccuracyPercent * 100;
	}

	IEnumerator showui ()
	{
		yield return new WaitForSecondsRealtime (1);
		StageResults.SetActive (true);
		if (ShotsHit > 0 && ShotsFired > 0) {
			float temp = (float)ShotsHit / (float)ShotsFired;
			AccuracyPercent = temp;
		}
		Tickets = 50 * AccuracyPercent;
		Mathf.Round (Tickets);
		int t = PlayerPrefs.GetInt("TotalTicket");
		t += (int)Tickets;
		PlayerPrefs.SetInt ("TotalTicket", t);

		Time.timeScale = 0;
		if (Stage1ShotsFired == 0 && Stage1ShotsHit == 0) {
			Stage1ShotsFired = ShotsFired;
			Stage1ShotsHit = ShotsHit;
		}
		else if (Stage2ShotsFired == 0 && Stage2ShotsHit == 0) {
			StageNum++;
			Stage2ShotsFired = ShotsFired;
			Stage2ShotsHit = ShotsHit;
		}
		else if (Stage3ShotsFired == 0 && Stage3ShotsHit == 0) {
			StageNum++;
			Stage3ShotsFired = ShotsFired;
			Stage3ShotsHit = ShotsHit;
		}

		yield return new WaitForSecondsRealtime (4);
		Tickets = 0;
		minute = 0;
		timer = 0;
		ShotsHit = 0;
		ShotsFired = 0;

		StageResults.SetActive (false);
		Time.timeScale = 1;
	}
}
