using UnityEngine;
using System.Collections;

public class CoverScript : MonoBehaviour {

	public string Default;
	public string BoxCover;
	public GameObject[] box;
	public bool crouch = false;
	public GameObject gun;

	bool CanCover;
	bool reloaded = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//gets space button press
		if (Input.GetKeyUp (KeyCode.Space) || crouch) {
			//comes out of cover
			crouch = false;
				GetComponent<Animator> ().SetTrigger (Default);
			}

		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag ("Cover")) {
			if (!reloaded) {
				reloaded = true;
				gun.GetComponent<Animator> ().SetTrigger ("Trig");
			}
		}
		else if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag ("OutOfCover")) {
				reloaded = false;
		}
	}
		
}
