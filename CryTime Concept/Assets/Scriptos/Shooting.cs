using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Shooting : MonoBehaviour {

	public float hitdist = 20.0f;
	public GameObject gun;
	GameObject enemy;
	public RawImage[] clip;
	bool outofammo;
	public Text Reload;
	public Texture2D cursor;
	CursorMode cursormode = CursorMode.Auto;
	Vector2 hotspot = Vector2.zero;
	bool reloadin;
	int atakState = Animator.StringToHash("OutOfCover");
	public Ray VRRay;
	public bool fire = false;
	public GameObject player;
	public GameObject controller;
	public RawImage crosshair;
	public RectTransform canvas;
	public Camera cam;
	Ray RayInGame;



	// Use this for initialization
	void Start (){
		Cursor.SetCursor (cursor, hotspot, cursormode);
	}

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		//makes this camera the main camera
		//creates a ray from the vive controllers position
		Ray ray2 = new Ray (controller.transform.position, controller.transform.forward);
		//checks to see if the ray hit the plane with the texture on it
		if (Physics.Raycast (ray2, out hit, LayerMask.GetMask ("VRScreen"))) 
		{
			//this gets the position on the texture where the ray hit
			Vector2 uv = hit.textureCoord;
			//this is a new ray that comes out of the camera that moves around the level with the direction of the texture position
			RayInGame = cam.ViewportPointToRay (uv);
			//this sets the crosshair to be where you are pointing the controllers
			crosshair.transform.localPosition = new Vector2(uv.x * canvas.rect.width - canvas.rect.width / 2, uv.y * canvas.rect.height- canvas.rect.height / 2);
		}

		if (!transform.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("OutOfCover")) {
			Reload.gameObject.SetActive (false);
			foreach (RawImage bullet in clip) {
				if (bullet.gameObject.activeSelf == false) {
					bullet.gameObject.SetActive (true);
				}
			}
		}
		//gets left mouse down
		if (Input.GetKeyDown (KeyCode.Mouse0) || fire) {
			fire = false;
			if (!reloadin) {
				if (transform.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag ("OutOfCover")) {
			
					//gets the mouse position ray
					foreach (RawImage bullet in clip) {
						//removes a bullet when player shoots
						if (bullet.gameObject.activeSelf == true) {
							bullet.gameObject.SetActive (false);
							break;
						}
					}
					//checks to see if you're out of ammo
					foreach (RawImage bullet in clip) {
						if (bullet.gameObject.activeSelf) {
							outofammo = false;
							break;
						} else {
							outofammo = true;
						}

					}
					//if the player is out of ammo
					if (outofammo) {
						Reload.gameObject.SetActive (true);
					} 


					Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
					RaycastHit hit2;
					//checks if the mouse is clicking something, eg an enemy behind the mouse
					if (!outofammo) {
						if (Physics.Raycast (RayInGame, out hit, 500000)) {
							//if the object that the mouse is on is an enemy
							Debug.Log(hit.collider.name);
							if (hit.collider.tag == "Enemy") {
								//it will destroy the enemy
								hit.collider.gameObject.SetActive (false);

							}
						}
					}
						if (Physics.Raycast (ray, out hit2, 500)) {
							//if the object that the mouse is on is an enemy
							if (hit2.collider.tag == "Enemy") {
								//it will destroy the enemy
								hit2.collider.gameObject.SetActive (false);


							}
						}
					}



				}

			}
		}
}
				




