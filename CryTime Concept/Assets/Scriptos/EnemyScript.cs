using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public Rigidbody bullet;
	Rigidbody newbullet;
	public GameObject player;
	public string Trigger;
	bool crouching;
	public bool activate;
	public GameObject Enemy;
	public GameObject gun;

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
		
		float randx = 0, randy = 0, randz = 0;
		//if the enemy is a "blue" enemy
		if (transform.name == "EnemyBlue") {
			//it will randomly give the bullet an offset so the bullets don't shoot straight every time
			randx = Random.Range (0, 3);
			randy = Random.Range (0, 3);
			randz = Random.Range (0, 3);
		}
		if (transform.name == "EnemyRed") {
			//it will randomly give the bullet an offset so the bullets don't shoot straight every time
			randx = Random.Range (0, 2);
			randy = Random.Range (0, 2);
			randz = Random.Range (0, 2);
		}
		//Creates a new bullet
			Enemy.GetComponent<Animator> ().SetTrigger ("Shooting");
			StartCoroutine (Delay (randx, randy, randz));
	}

	IEnumerator Timer()
	{
		while (true) {
			int rando = Random.Range (1, 4);
			Debug.Log (rando);
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
						Shoot ();
					}
					if (rand == 1) {
						StartCoroutine ("Crouch");
					}
				} 
			//Blue enemies will only shoot
			else {
					Shoot ();
				}
			
			}
	}
	}

	IEnumerator Delay(float rand1, float rand2, float rand3)
	{
		yield return new WaitForSeconds (.5f);
		newbullet = Instantiate (bullet, gun.transform.position, gun.transform.rotation) as Rigidbody;
		//shoots the bullet towards the player
		newbullet.velocity = ((player.transform.position + new Vector3(rand1, rand2, rand3)) - newbullet.transform.position).normalized * 50;

		//Destroy bullet gameobject after specified time
		Destroy (newbullet.gameObject, bulletLifeTime);
	}


	IEnumerator Crouch()
	{
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
