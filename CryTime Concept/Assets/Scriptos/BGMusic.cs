using UnityEngine;
using System.Collections;

public class BGMusic : MonoBehaviour {

	public GameObject player;
	public AudioClip Area1Music;
	public AudioClip Area2Music;
	public AudioClip BossMusic;

	Animator anim;
	bool played = true;
	bool played2 = true;

	// Use this for initialization
	void Start () {
		anim = player.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Anim1") && played) {
			played = false;
			transform.GetComponent<AudioSource> ().PlayOneShot (Area1Music);
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("CutSceneCoverDown1") && played2) {
			played2 = false;
			transform.GetComponent<AudioSource> ().PlayOneShot (BossMusic);
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("CutScene3")) {
			transform.GetComponent<AudioSource> ().Stop ();
		}
	}
}
