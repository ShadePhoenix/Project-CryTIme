using UnityEngine;
using System.Collections;

public class EnemyYelling : MonoBehaviour {

	public AudioClip OpenFire;
	public AudioClip fire;

	Animator anim;
	bool played = true;
	bool played2 = true;
	bool played3 = true;
	bool played4 = true;
	bool played5 = true;
	bool played6 = true;
	bool played7 = true;
	bool played8 = true;
	bool played9 = true;

	// Use this for initialization
	void Start () {
		anim = transform.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Anim3") && played) {
			played = false;
			StartCoroutine (wait (1.5f));
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("anim4") && played2) {
			played2 = false;
			transform.GetComponent<AudioSource> ().PlayOneShot (fire);
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Anim6") && played3) {
			played3 = false;
			StartCoroutine (wait (3));
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Tower1") && played4) {
			played4 = false;
			StartCoroutine (waitfire (8));
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Tower4Up") && played5) {
			played5 = false;
			StartCoroutine (waitfire (0));
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Tower5Anim") && played6) {
			played6 = false;
			StartCoroutine (wait (2.5f));
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Tower9Up") && played7) {
			played7 = false;
			StartCoroutine (wait (0));
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Tower12Anim") && played8) {
			played8 = false;
			StartCoroutine (waitfire (7));
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Tower15Anim") && played9) {
			played9 = false;
			StartCoroutine (wait (5.5f));
		}
	}

	IEnumerator wait(float time)
	{
		yield return new WaitForSeconds (time);
		transform.GetComponent<AudioSource> ().PlayOneShot (OpenFire);
	}
	IEnumerator waitfire(float time)
	{
		yield return new WaitForSeconds (time);
		transform.GetComponent<AudioSource> ().PlayOneShot (fire);
	}

}
