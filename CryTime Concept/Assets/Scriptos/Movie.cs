using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movie : MonoBehaviour {

	public MovieTexture movie;
	public GameObject player;
	public GameObject MovieUI;
	public RawImage img;
	public string Tag;
	public TotalTime tt;
	public CountDown cd;

	RawImage rawImageComp;
	public AudioSource audioS;

	public bool onetime = true;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
	}

	void PlayClip()
	{
		rawImageComp.texture = movie;
		movie.Play ();
		audioS.clip = movie.audioClip;
		audioS.Play ();
	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds (1);
		onetime = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag (Tag)) {
			if (movie.isPlaying == false && !onetime) {
				StartCoroutine (wait ());
				Time.timeScale = 1;
				cd.counting = true;
				tt.counting = true;
				MovieUI.SetActive (false);
				player.GetComponent<Animator> ().SetTrigger ("trig");
				player.GetComponent<Animator> ().SetTrigger ("CutSceneFin");
				player.GetComponent<Animator> ().SetTrigger ("done");
			}
		}

//		if (MovieUI.name == "FinalStage") {
//			if (MovieUI.activeSelf) {
//				Time.timeScale = 0;
//			}
//		}

		if (player.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag ("GameDone")) {
			if (MovieUI.name == "FinalScene") {
				if (!MovieUI.activeSelf) {
					SceneManager.LoadScene ("Main Menu");
				}
			}
		}

		if (player.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag (Tag) && onetime) 
		{
			Time.timeScale = 0;
			cd.counting = false;
			tt.counting = false;
			onetime = false;
			MovieUI.SetActive (true);
			rawImageComp = img.GetComponent<RawImage> ();
			audioS = img.GetComponent<AudioSource> ();
			PlayClip ();
		}

		if (Input.GetMouseButton (0)) {
			if (movie.isPlaying && MovieUI.activeSelf) {
				cd.counting = true;
				tt.counting = true;
				Time.timeScale = 1;
				MovieUI.SetActive (false);
				player.GetComponent<Animator> ().SetTrigger ("trig");
			}
		}
	}
}
