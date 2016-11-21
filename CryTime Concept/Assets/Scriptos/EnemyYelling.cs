using UnityEngine;
using System.Collections;

public class EnemyYelling : MonoBehaviour {

	public AudioClip OpenFire;
	public AudioClip fire;

	Animator anim;
	bool played = true;
	bool played2 = true;

	// Use this for initialization
	void Start () {
		anim = transform.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Anim3") && played) {
			played = false;
			StartCoroutine (wait ());
		}
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("anim4") && played2) {
			played2 = false;
			transform.GetComponent<AudioSource> ().PlayOneShot (fire);
		}
	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds (1.5f);
		transform.GetComponent<AudioSource> ().PlayOneShot (OpenFire);;
	}

}
