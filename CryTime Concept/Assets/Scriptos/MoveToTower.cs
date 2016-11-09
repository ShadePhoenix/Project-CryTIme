using UnityEngine;
using System.Collections;

public class MoveToTower : MonoBehaviour {

	public GameObject[] PrevEnemies;
	public GameObject Helicopter;
	public GameObject player;
	bool enemiesalive = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		foreach (GameObject enemy in PrevEnemies) {
			if (enemy.activeSelf) {
				enemiesalive = true;
				break;
			}
			enemiesalive = false;
		}

		if (!enemiesalive) {
			player.GetComponent<Animator> ().SetTrigger ("Tower1Anim");
			Helicopter.GetComponent<Animator> ().SetTrigger ("Animate");
		}
	
	}
}
