using UnityEngine;
using System.Collections;

public class EnemyDieSafety : MonoBehaviour {

	public GameObject particle;

	bool once = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//safety code incase the enemies don't die when they are meant too
		if (transform.GetChild(0).GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Dead") && once) {
			once = false;
			StartCoroutine (die ());
		}
	
	}

	IEnumerator die()
	{
		//adds a particle to the enemies on death
		Instantiate (particle, transform.position, Quaternion.Euler (270, 0, 0));
		yield return new WaitForSeconds (1);
		transform.gameObject.SetActive (false);
	}
}
