using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movie : MonoBehaviour {

	public MovieTexture movie;
	public GameObject player;
	public GameObject MovieUI;
	public RawImage img;
	public string Tag;

	RawImage rawImageComp;
	public AudioSource audioS;

	bool onetime = true;

	// Use this for initialization
	void Start () {
	
	}

	void PlayClip()
	{
		rawImageComp.texture = movie;
		movie.Play ();
		audioS.clip = movie.audioClip;
		audioS.Play ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!movie.isPlaying && !onetime) {
			onetime = true;
			MovieUI.SetActive (false);
			player.GetComponent<Animator> ().SetTrigger ("CutSceneFin");
		}

		if (player.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag (Tag) && onetime) {
			onetime = false;
			MovieUI.SetActive (true);
			rawImageComp = img.GetComponent<RawImage> ();
			audioS = img.GetComponent<AudioSource> ();
			PlayClip ();
		}

		if (!movie.isPlaying && !onetime) {
			player.GetComponent<Animator> ().SetTrigger ("done");
		}
	
	}
}
