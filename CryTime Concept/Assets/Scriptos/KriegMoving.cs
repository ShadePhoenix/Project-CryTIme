using UnityEngine;
using System.Collections;

public class KriegMoving : MonoBehaviour {

	public AudioClip ShootSound;
	public Rigidbody bullet;
	public GameObject Krieg;
	public GameObject player;
	public GameObject gun;
	public float Min;
	public float Max;
	public int health = 60;
	public CountDown countdown;
	public AddTime addtime;

	bool firstpoint = false;
	bool secondpoint = false;
	bool thirdpoint = false;
	bool fourthpoint = false;
	bool fifthpoint = false;
	bool sixthpoint = false;
	bool seventhpoint = false;
	bool eightpoint = false;
	Rigidbody newbullet;
	IEnumerator co;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//depending on kriegs health will depend on where he comes in and out from
		if (health <= 40) {
			player.GetComponent<Animator> ().SetTrigger ("SecondBossPart");
			transform.GetComponent<Animator> ().SetTrigger ("Animate");
		}

		if (player.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("CutSceneCoverDown1") && !firstpoint) {
			StartCoroutine (Refresh ());
			firstpoint = true;
			GoToCover ();
		}

		if (health > 44 && health < 51 && !secondpoint) {
			secondpoint = true;
			GoToCover ();
		}
		if (health > 39 && health < 45 && !thirdpoint) {
			thirdpoint = true;
			GoToCover ();
		}
		if (health > 34 && health < 40 && !fourthpoint) {
			fourthpoint = true;
			GoToCover ();
		}
		if (health > 29 && health < 35 && !fifthpoint) {
			fifthpoint = true;
			GoToCover ();
		}
		if (health > 24 && health < 30 && !sixthpoint) {
			sixthpoint = true;
			GoToCover ();
		}
		if (health > 19 && health < 25 && !seventhpoint) {
			player.GetComponent<Animator> ().SetTrigger ("LastPoint");
			seventhpoint = true;
			GoToCover ();
		}
		if (health > 14 && health < 20 && !eightpoint) {
			seventhpoint = true;
			GoToCover ();
		}
		if (health < 15) {
			player.GetComponent<Animator> ().SetTrigger ("FinalTrigger");
		}
	
	}

	void GoToCover()
	{
		//a bunch of different animations and positions depending on health
		if (health > 50) {
			transform.GetComponent<Animator> ().SetTrigger ("Up1");
			co = InCover ("Up1", "Down1");

			StartCoroutine (co);
		}
		if (health > 44 && health < 51) {
			transform.GetComponent<Animator> ().SetTrigger ("Down2");
			transform.GetComponent<Animator> ().SetTrigger ("Up2");
			StopCoroutine (co);
			co = InCover ("Up2", "Down2");
			StartCoroutine (co);
		}
		if (health > 39 && health < 45) {
			transform.GetComponent<Animator> ().SetTrigger ("Down3");
			transform.GetComponent<Animator> ().SetTrigger ("Up3");
			StopCoroutine (co);
			co = InCover ("Up3", "Down3");
			StartCoroutine (co);
		}
		if (health > 34 && health < 40) {
			countdown.count += 10;
			StartCoroutine (addtime.Extend ());
			transform.GetComponent<Animator> ().SetTrigger ("Down4");
			transform.GetComponent<Animator> ().SetTrigger ("Up4");
			StopCoroutine (co);
			co = InCover ("Up4", "Down4");
			StartCoroutine (co);
		}
		if (health > 29 && health < 35) {
			transform.GetComponent<Animator> ().SetTrigger ("Down5");
			transform.GetComponent<Animator> ().SetTrigger ("Up5");
			StopCoroutine (co);
			co = InCover ("Up5", "Down5");
			StartCoroutine (co);
		}
		if (health > 24 && health < 30) {
			transform.GetComponent<Animator> ().SetTrigger ("Down6");
			transform.GetComponent<Animator> ().SetTrigger ("Up6");
			StopCoroutine (co);
			co = InCover ("Up6", "Down6");
			StartCoroutine (co);
		}
		if (health > 19 && health < 25) {
			StartCoroutine (addtime.Extend ());
			countdown.count += 10;
			transform.GetComponent<Animator> ().SetTrigger ("Down7");
			transform.GetComponent<Animator> ().SetTrigger ("Up7");
			StopCoroutine (co);
			co = InCover ("Up7", "Down7");
			StartCoroutine (co);
		}
		if (health < 20) {
			transform.GetComponent<Animator> ().SetTrigger ("Down8");
			transform.GetComponent<Animator> ().SetTrigger ("Up8");
			StopCoroutine (co);
			co = InCover ("Up8", "Down8");
			StartCoroutine (co);
		}

	}

	IEnumerator InCover(string up, string down)
	{
		while (true) {
			int rand = Random.Range (0, 5);
			if (rand == 0) {
				transform.GetComponent<Animator> ().SetTrigger (down);
			}
			int randtime = Random.Range (0, 4);
			yield return new WaitForSeconds (1);
			transform.GetComponent<Animator> ().SetTrigger (up);
		}
	}

	IEnumerator Refresh()
	{
		while (true) {
			Shoot ();
			yield return new WaitForSeconds (1);
		}
	}

	void Shoot()
	{
		if (transform.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag("Up")) {
			float randx = 0, randy = 0, randz = 0;
			randx = Random.Range (Min, Max);
			randy = Random.Range (Min, Max);
			randz = Random.Range (Min, Max);
			transform.GetComponent<AudioSource> ().PlayOneShot (ShootSound);
			newbullet = Instantiate (bullet, gun.transform.position, gun.transform.rotation) as Rigidbody;
			newbullet.velocity = ((player.transform.position + new Vector3 (randx, randy, randz)) - newbullet.transform.position).normalized * 50;
			newbullet.transform.LookAt (player.transform.position);
			Krieg.GetComponent<Animator> ().SetTrigger ("Shoot");
		}
	}

}
