using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Accuracy : MonoBehaviour {

	public BGMusic bgmusic;
	public AudioClip completesound;
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

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = player.GetComponent<Animator> ();
	}

	IEnumerator FinalStageScreen()
	{
		TotalShotsHit = Stage1ShotsHit + Stage2ShotsHit + Stage3ShotsHit;
		TotalShotsFired = Stage1ShotsFired + Stage2ShotsFired + Stage3ShotsFired;
		WholeShots.text = "(" + TotalShotsHit + "/" + TotalShotsFired + ")";
		float totalAcc = (float)TotalShotsHit / (float)TotalShotsFired;
		WholeAcc.text = "" + totalAcc * 100;
		WholeTime.text =  ttime.minute + ":" + Mathf.Round(ttime.timer * 100f) / 100f;
		Tickets = 200 * totalAcc;
		Mathf.Round (Tickets);
		int t = PlayerPrefs.GetInt("TotalTicket");
		t += (int)Tickets;
		PlayerPrefs.SetInt ("TotalTicket", t);
		WholeTickets.text = "" + Mathf.Round (Tickets);
		FinalResults.SetActive (true);
		yield return new WaitForSecondsRealtime (5);
		FinalResults.SetActive (false);
		Time.timeScale = 1;

	}
	
	// Update is called once per frame
	void Update () {
		//checks what animation state the player is in
		if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("CutScene2")) {
			//starts a coroutine
			StartCoroutine (FinalStageScreen ());
			//stops the game
			Time.timeScale = 0;
		}

		//this is a basic timer
		timer = timer + Time.deltaTime;
		if (timer >= 60) {
			timer = 0;
			minute++;
		}
		//checks what animation state the player is in
		if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("StageComplete1") && stagecom) {
			//stops this if statement from repeating
			stagecom = false;
			//starts coroutine to show the UI
			StartCoroutine (showui ());
		} 
		//checks what animation state the player is in
		if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("StageComplete2") && stagecom2) {
			//stops this if statement from repeating
			stagecom2 = false;
			//starts coroutine to show the UI
			StartCoroutine (showui ());
		} 
		//checks what animation state the player is in
		if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("StageComplete3") && stagecom3) {
			//stops this if statement from repeating
			stagecom3 = false;
			//starts coroutine to show the UI
			StartCoroutine (showui ());
		} 

		//sets the amount of tickets earned text to be the amount earned in that stage
		//the tickets are started as a float, the round function rounds the tickets up
		//to an int
		TicketsEarned.text = "" + Mathf.Round (Tickets);
		//this gets the total time of the stage, this does some fancy math to display the
		//time in a digital clock form
		TotalTime.text =  minute + ":" + Mathf.Round(timer * 100f) / 100f;
		StageNumber.text = "" + StageNum;
		AccuracyText.text = "(" + ShotsHit + "/" + ShotsFired + ")";
		Mathf.Round (AccuracyPercent);
		//the accuracy is displayed multiplied by 100 to show a full number eg 98 rather then .8
		TotalAccuracyText.text = "" + AccuracyPercent * 100;
	}

	IEnumerator showui ()
	{
		bgmusic.GetComponent<AudioSource> ().Stop ();
		yield return new WaitForSecondsRealtime (1);
		player.GetComponent<AudioSource> ().PlayOneShot (completesound);
		StageResults.SetActive (true);
		//this checks to make sure you have fired a shot before finding the accuracy
		if (ShotsHit > 0 && ShotsFired > 0) {
			//this devides the shots hit and shots fired to find the accuracy
			float temp = (float)ShotsHit / (float)ShotsFired;
			AccuracyPercent = temp;
		}
		//the amount of tickets earned is multiplied by your accuracy eg 50 * .71
		Tickets = 50 * AccuracyPercent;
		//it then rounds the tickets up to an int
		Mathf.Round (Tickets);
		//this gets your global ticket count
		int t = PlayerPrefs.GetInt("TotalTicket");
		//then adds the tickets earned from this stage to your total tickets
		t += (int)Tickets;
		//it then saves this
		PlayerPrefs.SetInt ("TotalTicket", t);
		//this stops the game so the player can't control anything
		Time.timeScale = 0;
		//these statements gets the amount of shots fired and hit for each stage
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
		if (StageNum == 1) {
			bgmusic.GetComponent<AudioSource> ().PlayOneShot (bgmusic.Area2Music);
		}
		if (StageNum == 2) {
			bgmusic.GetComponent<AudioSource> ().PlayOneShot (bgmusic.BossMusic);
		}
		//sets each variable to 0 upon starting a new stage
		Tickets = 0;
		minute = 0;
		timer = 0;
		ShotsHit = 0;
		ShotsFired = 0;

		StageResults.SetActive (false);
		Time.timeScale = 1;
	}
}
