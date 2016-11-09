using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveJets : MonoBehaviour {

	public GameObject Jet1;
	bool Jet1Done = false;
	public GameObject Jet2;
	bool Jet2Done = false;
	public GameObject Jet3;
	bool Jet3Done = false;
	public RawImage Danger;
	public float time;

	private bool startflash = false;
	private bool stop = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag ("Cover") && Jet2Done) {
			if (stop == true) {
				Danger.gameObject.SetActive (false);
			}
		}
		if (transform.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag ("OutOfCover") && Jet2Done) {
			if (stop == true) {
				Danger.gameObject.SetActive (true);
			}
		}

		if (transform.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("OutOfCover 1") && !Jet1Done) {
			Jet1Done = true;
			Jet1.GetComponent<Animator> ().SetTrigger ("Animate");
		}
		if (transform.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("CoverDown4 0") && !Jet2Done) {
			Jet2Done = true;
			StartCoroutine (waitforsecs ());
			Jet2.GetComponent<Animator> ().SetTrigger ("Animate");
		}
		if (transform.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Anim5") && !Jet3Done) {
			Jet3Done = true;
			Jet3.GetComponent<Animator> ().SetTrigger ("Animate");
		}
	
	}


	IEnumerator waitforsecs()
	{
		yield return new WaitForSeconds (3);
		stop = false;
		Danger.gameObject.SetActive (false);
	}

}
