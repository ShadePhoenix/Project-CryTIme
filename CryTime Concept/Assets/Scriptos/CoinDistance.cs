using UnityEngine;
using System.Collections;

public class CoinDistance : MonoBehaviour {

	Vector3 originalpos;

	// Use this for initialization
	void Start () {

		originalpos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.collider.tag == "Coin") {
			Debug.Log("hi");
			transform.position = originalpos;
		}
	}
}
