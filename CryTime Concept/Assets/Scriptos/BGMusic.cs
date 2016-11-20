using UnityEngine;
using System.Collections;

public class BGMusic : MonoBehaviour {

	public GameObject player;
	public AudioClip Area1Music;
	public AudioClip Area2Music;
	public AudioClip BossMusic;

	Animator anim;
	bool played = true;

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
	}
}
