using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	public GameObject PauseMenu;

	bool clicked = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!clicked) {
				clicked = true;
				PauseMenu.SetActive (true);
				Time.timeScale = 0;
			} else {
				clicked = false;
				PauseMenu.SetActive (false);
				Time.timeScale = 1;
			}
		}
	
	}

	public void OnClick()
	{
		SceneManager.LoadScene ("Main Menu");	
	}

}
