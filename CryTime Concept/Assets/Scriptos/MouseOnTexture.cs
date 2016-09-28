using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.VR;

public class MouseOnTexture : MonoBehaviour {

	public Camera cam;
	Ray RayInGame;
	bool outofammo;
	public RawImage[] clip;
	public GameObject player;
	public GameObject controller;
	public RawImage crosshair;
	public RectTransform canvas;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//gets the position of the cursor
		Vector2 pos = Input.mousePosition;


		//makes sure you aren't out of ammo
		foreach (RawImage bullet in clip) {
			if (bullet.gameObject.activeSelf) {
				outofammo = false;
				break;
			} else {
				outofammo = true;
			}

		}
		//this is the same code from the shooting script
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			//if (player.transform.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag ("OutOfCover")) {
				if (!outofammo) {
				
			}
	}
	}


	//this just draws the rays in the editor
	void OnDrawGizmos()
	{
		Vector2 pos = Input.mousePosition;
		RaycastHit hit;
		Camera VRCam = Camera.main;
		Ray ray = new Ray (controller.transform.position, controller.transform.forward);

		if (Physics.Raycast (ray, out hit, LayerMask.GetMask ("VRScreen"))) {
			Vector2 uv = hit.textureCoord;

			RayInGame = cam.ViewportPointToRay (uv);
		}
		Gizmos.color = Color.red;
		Gizmos.DrawLine (controller.transform.position, hit.point);

	}
}
