using UnityEngine;
using System.Collections;

public class TowerEnemyOut : MonoBehaviour {

	public GameObject[] ThisEnemies;
	public GameObject[] EnemyMeshes;
	public GameObject player;
	public string CoverName;
	public string PlayerTrigger;

	bool EnemiesAlive = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (player.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName (CoverName)) {
			foreach (GameObject Enemy in ThisEnemies) {
				if (Enemy.GetComponent<EnemyScript> ()) {
					Enemy.GetComponent<EnemyScript> ().activate = true;
				}
				Enemy.GetComponent<Collider> ().enabled = true;
				Enemy.GetComponent<Animator> ().SetTrigger ("Animate");
			}
			foreach (GameObject Enemy in EnemyMeshes) {
				Enemy.SetActive (true);
			}
		}

		foreach (GameObject Enemy in ThisEnemies) {
			if (Enemy.activeSelf) {
				EnemiesAlive = true;
				break;
			}
			EnemiesAlive = false;
		}

		if (!EnemiesAlive) {
			player.GetComponent<Animator> ().SetTrigger (PlayerTrigger);
			foreach (GameObject Enemy in ThisEnemies) {
				if (Enemy.activeSelf)
				Enemy.GetComponent<EnemyScript> ().activate = true;

			}

		}
	
	}
}
