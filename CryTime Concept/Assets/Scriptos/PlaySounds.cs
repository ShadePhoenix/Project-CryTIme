using UnityEngine;
using System.Collections;

public class PlaySounds : MonoBehaviour {

	public Camera VRMode;
	public GameObject FPSCam;
	public GameObject machine;
	public AudioClip GunSounds;
	public AudioClip ReloadSounds;
	public AudioClip Engage;
	public AudioClip StandBy;
	public AudioClip Danger;
	public AudioClip warning;

	public MoveJets dangerjet;
	bool playoneshot = true;
	bool DoEngage = true;
	bool DoStandBy = true;
	bool DoDanger = true;
	bool DoWarning = true;

	Animator anim;


	// Use this for initialization
	void Start () {
		anim = FPSCam.GetComponent<Animator> ();
	}

	IEnumerator waitStandby()
	{
		yield return new WaitForSeconds (8);
		DoStandBy = true;
	}
	IEnumerator waitEngage()
	{
		yield return new WaitForSeconds (6);
		DoEngage = true;
	}

	void Update()
	{
		if (anim.GetCurrentAnimatorStateInfo (0).IsTag("Engage")) {
			if (DoEngage) {
				DoEngage = false;
				StartCoroutine (waitEngage());
				if (VRMode.gameObject.activeSelf) {
					AudioSource.PlayClipAtPoint (Engage, machine.transform.position);
				} else {
					FPSCam.GetComponent<AudioSource> ().PlayOneShot (Engage);
				}
			}
		}
				if (anim.GetCurrentAnimatorStateInfo (0).IsTag("Moving")) {
			if (DoStandBy) {
				DoStandBy = false;
				StartCoroutine (waitStandby ());
						if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("Tower13Anim")) {
					if (VRMode.gameObject.activeSelf) {
						AudioSource.PlayClipAtPoint (StandBy, machine.transform.position);
					} else {
						FPSCam.GetComponent<AudioSource> ().PlayOneShot (StandBy);
					}
				}
			}
		}
				if (anim.GetCurrentAnimatorStateInfo (0).IsName ("CoverDown4 0")) {
				if (DoDanger) {
					DoDanger = false;
					if (VRMode.gameObject.activeSelf) {
						AudioSource.PlayClipAtPoint (Danger, machine.transform.position);
					} else {
					FPSCam.GetComponent<AudioSource> ().PlayOneShot (Danger);
					}
				}
		}
				if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Tower13Anim")) {
			if (playoneshot) {
				FPSCam.GetComponent<AudioSource> ().Stop ();
				if (VRMode.gameObject.activeSelf) {
					AudioSource.PlayClipAtPoint (warning, machine.transform.position);
				} else {
					FPSCam.GetComponent<AudioSource> ().PlayOneShot (warning);
				}
				playoneshot = false;
			}
		}
	}

	public void PlayShootSound()
	{
		if (VRMode.gameObject.activeSelf) {
			AudioSource.PlayClipAtPoint (GunSounds, machine.transform.position);
		} else {
			FPSCam.GetComponent<AudioSource> ().PlayOneShot (GunSounds);
		}
	}

	public void Reload()
	{
		if (VRMode.gameObject.activeSelf) {
			AudioSource.PlayClipAtPoint (ReloadSounds, machine.transform.position);
		} else {
			FPSCam.GetComponent<AudioSource> ().PlayOneShot (ReloadSounds);
		}
	}
	
	// Update is called once per frame

}
