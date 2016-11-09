using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public int Min; public int Max;
	public Rigidbody bullet;
	Rigidbody newbullet;
	public GameObject player;
	public string Trigger;
	bool crouching;
	public bool activate;
	public GameObject Enemy;
	public GameObject gun;
	public GameObject gun2;
	public GameObject MuzzleNormal;

	GameObject particle;
	public float bulletLifeTime = 2f;

	// Use this for initialization
	void Start () {
	//starts the loop
		StartCoroutine ("Timer");
	}
	
	// Update is called once per frame
	void Update () {
			if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag ("Finished")) {
				Enemy.GetComponent<Animator> ().SetTrigger ("Default");
			}
	}

	void Shoot()
	{

		if (transform.name == "EnemyPurple") {
			if (transform.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag ("Ducked")) {
				Enemy.GetComponent<Animator> ().SetTrigger ("StopShooting");
			}
		}
		
		float randx = 0, randy = 0, randz = 0;
		randx = Random.Range (Min, Max);
		randy = Random.Range (Min, Max);
		randz = Random.Range (Min, Max);
		//Creates a new bullet
		if (GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag ("Finished")) {
			Enemy.GetComponent<Animator> ().SetTrigger ("Shooting");
			StartCoroutine (Delay (randx, randy, randz, gun));
			if (transform.name == "EnemyRed") {
				StartCoroutine (Delay (randx, randy, randz, gun2));
			}
		}
	}

	IEnumerator Timer()
	{
		while (true) {
			int rando = Random.Range (1, 4);
			yield return new WaitForSeconds (rando);
			//Every 2 seconds, it will call the "shoot" functions
			//Only red enemy will do the following
			//also makes sure the enemy isnt already crouching
			if (activate) {
				if (!crouching && transform.name == "EnemyPurple") {
					int rand = Random.Range (0, 2);
					//50/50 chance of shooting or crouching

					//checks if the mouse is clicking something, eg an enemy behind the mouse
					if (rand == 0) {
						if (transform.name == "EnemyPurple") {
							//it will randomly give the bullet an offset so the bullets don't shoot straight every time
							float randx, randy, randz;
							randx = Random.Range (Min, Max);
							randy = Random.Range (Min, Max);
							randz = Random.Range (Min, Max);
							StartCoroutine(Shoot3());
						}
					}
					if (rand == 1) {
						StartCoroutine (Crouch());
					}
				} 
			//Blue enemies will only shoot
			else {
					Shoot ();
				}
			
			}
	}
	}

	IEnumerator Shoot3 ()
	{
		Shoot ();
		yield return new WaitForSeconds (.1f);
		Shoot ();
		yield return new WaitForSeconds (.1f);
		Shoot ();
		yield return new WaitForSeconds (.1f);
		Shoot ();
		yield return new WaitForSeconds (.1f);
		Shoot ();
	}

	IEnumerator Delay(float rand1, float rand2, float rand3, GameObject Gun)
	{
		yield return new WaitForSeconds (.5f);
		particle = Instantiate (MuzzleNormal, gun.transform.position, gun.transform.rotation) as GameObject;
		newbullet = Instantiate (bullet, Gun.transform.position, gun.transform.rotation) as Rigidbody;
		//shoots the bullet towards the player
		newbullet.velocity = ((player.transform.position + new Vector3(rand1, rand2, rand3)) - newbullet.transform.position).normalized * 50;
		newbullet.transform.LookAt (player.transform.position);

		//Destroy bullet gameobject after specified time
		Destroy (newbullet.gameObject, bulletLifeTime);
		Destroy (particle, .2f);
	}


	IEnumerator Crouch()
	{
		if (Enemy.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag ("Shooting")) {
			//does the crouch down animation
			transform.GetComponent<Animator> ().SetTrigger (Trigger);
			crouching = true;
			//waits a 1.5 seconds
			yield return new WaitForSeconds (1.5f);
			//then the enemy will come back up
			transform.GetComponent<Animator> ().SetTrigger (Trigger);
			crouching = false;		
		}
	}



}
