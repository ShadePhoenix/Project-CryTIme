using UnityEngine;
using System.Collections;

public class MoreEnemies : MonoBehaviour {

	public GameObject[] enemies;
	public GameObject[] nextenemies;
	public GameObject[] objects;
	bool enemiesalive;
	bool comeout = false;
	public int speed = 1;
	public string Trigger;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//checks to see if previous enemies are dead, the reason for this is so more enemies can come out when others die
		foreach (GameObject enemy in enemies) {
			if (enemy.activeSelf) {
				enemiesalive = true;
				break;
			} else {
				enemiesalive = false;
			}
		}
		if (enemiesalive) {
			foreach (GameObject enemy in nextenemies) {
				enemy.GetComponent<EnemyScript>().activate = false;
			}
		}
		//this code will only happen for the pos with the name "Pos (1)" it also makes sure all previous enemies are dead
		if (this.name == "Pos (1)" && !enemiesalive) {
			//stats the wait coroutine
				StartCoroutine ("wait");
			} else {
				if (!enemiesalive || enemies.Length <= 0) {
				//moves players to specific points
				foreach (GameObject enemy in nextenemies) {
					enemy.GetComponent<EnemyScript>().activate = true;
					enemy.GetComponent<Animator> ().SetTrigger (Trigger);
				}
				foreach (GameObject obj in objects) {
					obj.GetComponent<Animator> ().SetTrigger (Trigger);
				}
				}
			}
		if (comeout) {
			foreach (GameObject enemy in nextenemies) {
				enemy.GetComponent<EnemyScript>().activate = true;
				enemy.GetComponent<Animator> ().SetTrigger (Trigger);
			}
			foreach (GameObject obj in objects) {
				obj.GetComponent<Animator> ().SetTrigger (Trigger);
			}
			}
		}


	IEnumerator wait()
	{
		yield return new WaitForSeconds (speed);
		//waits for specific seconds then turns this bool to true
		comeout = true;
	}

}
