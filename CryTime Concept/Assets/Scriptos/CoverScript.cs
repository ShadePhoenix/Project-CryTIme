using UnityEngine;
using System.Collections;

public class CoverScript : MonoBehaviour {

	public string Default;
	public string BoxCover;
	public GameObject[] box;
	public bool crouch = false;

	bool CanCover;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//gets space button press
		if (Input.GetKeyUp (KeyCode.Space) || crouch) {
			//comes out of cover
			crouch = false;
				GetComponent<Animator> ().SetTrigger (Default);
			}
		}
		
}
