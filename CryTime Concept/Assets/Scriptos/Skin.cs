using UnityEngine;
using System.Collections;

public class Skin : MonoBehaviour {

	public GameObject KK;
	public Material KKDefuse;
	public GameObject Default;
	public Material DefaultDefuse;

	public GameObject Body;


	// Use this for initialization
	void Start () {
		int rand = Random.Range (0, 2);
		if (rand == 0) {
			KK.SetActive (true);
			Body.GetComponent<Renderer> ().material = KKDefuse;
		}
		if (rand == 1) {
			Default.SetActive (true);
			Body.GetComponent<Renderer> ().material = DefaultDefuse;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
