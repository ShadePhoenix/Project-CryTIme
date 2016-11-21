using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Playerhit : MonoBehaviour {

	public AudioClip damagesound;
	public RawImage[] health;
	public bool GameOver = false;
	public GameObject GO;
	public GameObject button1;
	public GameObject button2;
	public GameObject playercamera;
	bool fade = false;
	public RawImage hit;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		foreach (RawImage h in health) {
			//checks if the player has health
			if (h.gameObject.activeSelf) {
				GameOver = false;
				break;
			} else {
				//if all the images are inactive, its game over
				GameOver = true;
			}
		}

		if (fade) {
			//this does the fade effect on the camera when player is hit
			//rather then turning the effect off instantly, it slowly goes back to normal
		}

		if (GameOver) {
			//if gameover, do this code
			foreach (RawImage h in health) {
				if (!h.gameObject.activeSelf) {
					h.gameObject.SetActive (true);
				}
			}
			GameOver = false;
			GO.SetActive(true);
			Time.timeScale = 0.0001f;
			StartCoroutine (wait ());

		}
	}

	IEnumerator wait ()
	{
		yield return new WaitForSecondsRealtime (1);
		button1.SetActive (true);
		button2.SetActive (true);
	}

	public void Continue()
	{
		GameOver = false;
		foreach (RawImage h in health) {
			if (!h.gameObject.activeSelf) {
				h.gameObject.SetActive (true);
			}
		}
	}

	void OnTriggerEnter(Collider col)
	{
		//checks if bullets hit player
		if (col.GetComponent<Collider>().tag == "Bullet") {
			if (transform.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag ("OutOfCover")) {
				transform.GetComponent<AudioSource> ().PlayOneShot (damagesound);
				StartCoroutine ("bullethit");
				transform.GetComponent<Animator> ().SetTrigger ("Default");
				//sets the effect to be in full, meaning the camera will be very blury
				fade = true;
				Destroy (col.GetComponent<Collider>().gameObject);
			}
		}
	}

	IEnumerator bullethit()
	{
		foreach (RawImage h in health) {
			//removes a health bar if hit, if hit 3 times, all health will be gone
			if (h.gameObject.activeSelf) {
				h.gameObject.SetActive (false);
				break;
			}
		}
		hit.gameObject.SetActive (true);
		yield return new WaitForSeconds(0.2f);
		hit.gameObject.SetActive(false);
	}

}
