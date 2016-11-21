using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour {

	public AudioClip explosionsound;
	public GameObject Explosion;
	public GameObject player;
	public Rigidbody bullet;
	public GameObject Gun;
	public GameObject Gun2;
	public string Location;
	public int Health;
	public int Min; public int Max;

	Rigidbody newbullet;
	bool done = false;
	bool crashed = false;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = transform.GetComponent<Animator> ();
		StartCoroutine (keepshooting ());
	}
	
	// Update is called once per frame
	void Update () {

		float dist = Vector3.Distance (player.transform.position, transform.position);
		dist *= 10;
		if (dist <= 1000) {
			transform.GetComponent<AudioSource> ().volume = .5f;
		}
		else if (dist <= 500) {  
			transform.GetComponent<AudioSource> ().volume = .7f;
		}
		else if (dist <= 400) {  
			transform.GetComponent<AudioSource> ().volume = 1;
		}
		else {
			transform.GetComponent<AudioSource> ().volume = 0;
		}

		//if the helis health gets to 0, animate it crashing
		if (Health <= 0 && !crashed) {
			crashed = true;
			transform.GetComponent<Animator> ().SetTrigger ("Crash");
			transform.GetComponent<AudioSource> ().PlayOneShot (explosionsound);
			Instantiate (Explosion, transform.position, Quaternion.Euler (270, 0, 0));
		}

		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Finished")) {
			transform.gameObject.SetActive (false);
		}

		if (player.GetComponent<Animator>().GetCurrentAnimatorStateInfo (0).IsName (Location) && !done) {
			done = true;
			transform.GetComponent<Animator> ().SetTrigger ("Animate2");
		}
	
	}

	IEnumerator keepshooting()
	{
		while (true) {
			float randomwait = Random.Range (.1f, .5f);
			StartCoroutine ("shoot");
			yield return new WaitForSeconds (randomwait);
		}
	}

	IEnumerator shoot()
	{
			if (transform.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag ("Attacking")) {
				float randx = 0, randy = 0, randz = 0;
				randx = Random.Range (Min, Max);
				randy = Random.Range (Min, Max);
				randz = Random.Range (Min, Max);
				newbullet = Instantiate (bullet, Gun.transform.position, Gun.transform.rotation) as Rigidbody;
				//shoots the bullet towards the player
				newbullet.velocity = ((player.transform.position + new Vector3 (randx, randy, randz)) - newbullet.transform.position).normalized * 50;

				newbullet = Instantiate (bullet, Gun2.transform.position, Gun2.transform.rotation) as Rigidbody;
				//shoots the bullet towards the player
				newbullet.velocity = ((player.transform.position + new Vector3 (randx, randy, randz)) - newbullet.transform.position).normalized * 50;

				//Destroy bullet gameobject after specified time
				Destroy (newbullet.gameObject, 1);

			yield return new WaitForSeconds (.1f);
			}

	}
}
