using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveJets : MonoBehaviour {

	public GameObject player;
	public GameObject Jet1;
	bool Jet1Done = false;
	public GameObject Jet2;
	public AudioClip jet1sound;
	public AudioClip jet2sound;
	public AudioClip jet3sound;
	public bool Jet2Done = false;
	public GameObject Jet3;
	bool Jet3Done = false;
	public RawImage Danger;
	public float time;

	private bool startflash = false;
	private bool stop = true;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = transform.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("Cover") && Jet2Done) {
			if (stop == true) {
				Danger.gameObject.SetActive (false);
			}
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("OutOfCover") && Jet2Done) {
			if (stop == true) {
				Danger.gameObject.SetActive (true);
			}
		}

		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("OutOfCover 1") && !Jet1Done) {
			Jet1Done = true;
			transform.GetComponent<AudioSource> ().PlayOneShot (jet1sound);
			Jet1.GetComponent<Animator> ().SetTrigger ("Animate");
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("CoverDown4 0") && !Jet2Done) {
			Jet2Done = true;
			StartCoroutine (waitforsecs ());
			transform.GetComponent<AudioSource> ().PlayOneShot (jet2sound);
			Jet2.GetComponent<Animator> ().SetTrigger ("Animate");
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Anim5") && !Jet3Done) {
			Jet3Done = true;
			Jet3.SetActive (true);
			transform.GetComponent<AudioSource> ().PlayOneShot (jet3sound);
			Jet3.GetComponent<Animator> ().SetTrigger ("Animate");
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Anim6")) {
			Jet3.SetActive (false);
		}
	
	}


	IEnumerator waitforsecs()
	{
		yield return new WaitForSeconds (3);
		stop = false;
		Danger.gameObject.SetActive (false);
	}

}
