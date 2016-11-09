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

		float dist = Vector3.Distance (originalpos, transform.position);
		if (dist > 1.5) {
			transform.position = originalpos;
		}
	
	}
}
