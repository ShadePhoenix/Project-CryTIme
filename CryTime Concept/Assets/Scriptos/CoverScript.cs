using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoverScript : MonoBehaviour {

	public string Default;
	public string BoxCover;
	public GameObject[] box;
	public RawImage[] bullets;
	public bool crouch = false;
	public GameObject gun;
	public RawImage ReloadText;

	bool CanCover;
	bool reloaded = false;
	bool empty;
	bool engage = true;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = transform.GetComponent<Animator> ();
	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds (1f);
		engage = true;
	}
	
	// Update is called once per frame
	void Update () {
		//gets space button press
		if (Input.GetKeyUp (KeyCode.Space) || crouch) {
			//comes out of cover
			crouch = false;
				GetComponent<Animator> ().SetTrigger (Default);
			}
		//Adds all bullets back to the clip
		if (anim.GetCurrentAnimatorStateInfo (0).IsTag("Engage") && engage) {
			engage = false;
			foreach (RawImage bullet in bullets) {
				if (bullet.gameObject.activeSelf == false) {
					bullet.gameObject.SetActive (true);
				}
			}
			//plays the reload sound
			transform.GetComponent<PlaySounds> ().Reload ();
			//reload animation plays
			gun.GetComponent<Animator> ().SetTrigger ("Trig");
			StartCoroutine (wait ());
		}
		//similar code yet when in cover and if you need to reload
		if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("Cover")) {
			if (!reloaded) {
				reloaded = true;
				empty = false;
				foreach (RawImage bullet in bullets) {
					if (bullet.gameObject.activeSelf == false) {
						empty = true;
					}
				}
				if (empty) {
					foreach (RawImage bullet in bullets) {
						if (bullet.gameObject.activeSelf == false) {
							bullet.gameObject.SetActive (true);
						}
					}
				ReloadText.gameObject.SetActive (false);
				transform.GetComponent<PlaySounds> ().Reload ();
				gun.GetComponent<Animator> ().SetTrigger ("Trig");
				}
			}
		}
		else if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag ("OutOfCover")) {
				reloaded = false;
		}
	}
		
}
