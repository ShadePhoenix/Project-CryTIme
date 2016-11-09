using UnityEngine;
using System.Collections;

public class JetHitPlayer : MonoBehaviour {

	public Playerhit playerhit;
	public GameObject[] enemies;
	public GameObject particle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject enemy in enemies) {
			float dist = Vector3.Distance (enemy.transform.position, transform.position);
			dist *= 100;
			if (dist <= 1000) {
				StartCoroutine(die(enemy));
			}
		}
	}



	void OnCollisionEnter(Collision col)
	{
		if (col.collider.name == "Player") {
			playerhit.StartCoroutine ("bullethit");
		}
	}

	IEnumerator die (GameObject enemy)
	{
		enemy.GetComponent<EnemyScript> ().Enemy.GetComponent<Animator>().SetTrigger("Death");
		Instantiate (particle, enemy.transform.position, Quaternion.Euler (270, 0, 0));
		yield return new WaitForSeconds (.5f);
		enemy.gameObject.SetActive (false);
	}
}
