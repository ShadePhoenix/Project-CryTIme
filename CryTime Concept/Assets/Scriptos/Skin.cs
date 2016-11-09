using UnityEngine;
using System.Collections;

public class Skin : MonoBehaviour {

	public GameObject KK;
	public Material KKDefuse;
	public GameObject Default;
	public Material DefaultDefuse;
	public GameObject PG;
	public Material PGDefuse;

	public GameObject Body;


	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("DefaultEquiped") == 1) {
			Default.SetActive (true);
			Body.GetComponent<Renderer> ().material = DefaultDefuse;
		}
		if (PlayerPrefs.GetInt ("KittyCannonEquiped") == 1) {
			KK.SetActive (true);
			Body.GetComponent<Renderer> ().material = KKDefuse;
		}
		if (PlayerPrefs.GetInt ("PinappleGunEquiped") == 1) {
			PG.SetActive (true);
			Body.GetComponent<Renderer> ().material = PGDefuse;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
