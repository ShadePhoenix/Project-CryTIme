using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cracks : MonoBehaviour {

	public RawImage Health1;
	public RawImage Health2;
	public RawImage Health3;

	public RawImage Crack1;
	public RawImage Crack2;
	public RawImage Crack3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//shows cracks depending on health
		if (!Health1.gameObject.activeSelf) {
			Crack1.gameObject.SetActive (true);
		} else {
			Crack1.gameObject.SetActive (false);
		}
		if (!Health2.gameObject.activeSelf) {
			Crack2.gameObject.SetActive (true);
		}
		else {
			Crack2.gameObject.SetActive (false);
		}
		if (!Health3.gameObject.activeSelf) {
			Crack3.gameObject.SetActive (true);
		}
		else {
			Crack3.gameObject.SetActive (false);
		}
	
	}
}
