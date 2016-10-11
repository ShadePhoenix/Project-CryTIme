using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Positions : MonoBehaviour {

	public GameObject player;
	public RawImage StandBy;
	public RawImage Engage;
	bool end = false;
	public GameObject[] previousenemies;
	public GameObject[] nextenemies;
	public GameObject[] objects;
	public RawImage[] clip;
	public string trig;
	bool enemyalive;
	public string Trigger;

	bool start = true;


	// Use this for initialization
	void Start () {
		
		}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag ("Engage")) {
			StandBy.GetComponent<TextFlash> ().stop = true;
			StopCoroutine (StandBy.GetComponent<TextFlash> ().textflash (StandBy));
			StandBy.gameObject.SetActive (false);
			Engage.gameObject.SetActive (true);
		} else {
			Engage.gameObject.SetActive (false);
		}
		if (player.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag ("Moving")) {
			if (start) {
				start = false;
				StandBy.GetComponent<TextFlash> ().stop = false;
				StartCoroutine (StandBy.GetComponent<TextFlash> ().textflash (StandBy));
			}
		} 
		//checks the distance between the player and the position node
		float dist = Vector3.Distance (transform.position, player.transform.position);
		//makes sure that all enemies are dead before proceeding
		foreach (GameObject enemy in previousenemies) {
			if (enemy.activeSelf) {
				enemyalive = true;
				break;
			} else {
				enemyalive = false;
			}
		}
		if (previousenemies.Length == 0 || !enemyalive) {
			//the reason for this bool is so that if it has reached the node
			//when proceeding to the next node, it doesn't try and back track
			if (!end) {
				//moves the player to the position node
				if (transform.name != "Pos") {
					foreach (RawImage bullet in clip) {
						if (bullet.gameObject.activeSelf == false) {
							bullet.gameObject.SetActive (true);
						}
					}
				}
				foreach (GameObject obj in objects) {
					obj.GetComponent<Animator> ().SetTrigger (Trigger);
				}
				foreach (GameObject enemy in nextenemies) {
					player.GetComponent<Animator>().SetTrigger(trig);
					enemy.GetComponent<EnemyScript> ().activate = true;
				}
				end = true;
			}
		
			if (dist <= 0 && !end) {
				//once the player has gotten to the nodes position, it disables this bool
				end = true;
			}
		}
	}


		
}
