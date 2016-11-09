using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.GetComponent<Collider>().tag == "Bullet") {
			Destroy (col);
		}
	}

}
