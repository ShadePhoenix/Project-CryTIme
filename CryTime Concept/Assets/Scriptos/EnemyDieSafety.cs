using UnityEngine;
using System.Collections;

public class EnemyDieSafety : MonoBehaviour {

	public GameObject particle;

	bool once = true;

	GameObject obj;

	Animator anim;

	// Use this for initialization
	void Start () {
		obj = transform.GetChild (0).gameObject;
		anim = obj.GetComponent<Animator> ();
	}


	
	// Update is called once per frame
	void Update () {
		//safety code incase the enemies don't die when they are meant too
		if (anim.isActiveAndEnabled) {
			if (anim.GetCurrentAnimatorStateInfo (0).IsTag ("Dead") && once) {
				once = false;
				StartCoroutine (die ());
			}
		}
	}

	IEnumerator die()
	{
		//adds a particle to the enemies on death
		Instantiate (particle, transform.position, Quaternion.Euler (270, 0, 0));
		yield return new WaitForSeconds (1);
		transform.gameObject.SetActive (false);
		Destroy (particle.gameObject, 2f);
	}
}
