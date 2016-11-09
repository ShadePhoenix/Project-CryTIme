using UnityEngine;
using System.Collections;

public class PlaySounds : MonoBehaviour {

	public Camera VRMode;
	public GameObject FPSCam;
	public GameObject machine;
	public AudioClip GunSounds;
	public AudioClip ReloadSounds;

	// Use this for initialization
	void Start () {
	
	}

	public void PlayShootSound()
	{
		if (VRMode.gameObject.activeSelf) {
			AudioSource.PlayClipAtPoint (GunSounds, machine.transform.position);
		} else {
			AudioSource.PlayClipAtPoint (GunSounds, FPSCam.transform.position);
		}
	}

	public void Reload()
	{
		if (VRMode.gameObject.activeSelf) {
			AudioSource.PlayClipAtPoint (ReloadSounds, machine.transform.position);
		} else {
			AudioSource.PlayClipAtPoint (ReloadSounds, FPSCam.transform.position);
		}
	}
	
	// Update is called once per frame
	void Update () {



	
	}
}
