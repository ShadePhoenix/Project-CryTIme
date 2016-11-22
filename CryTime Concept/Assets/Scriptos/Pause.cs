using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	public GameObject PauseMenu;
	public GameObject OptionsMenu;
	public GameObject player;
	public GameObject vrplayer;
	public GameObject Options;
	public GameObject exit;
	public bool canpause = true;

	public Toggle Audio;
	public Toggle fullscreen;

	bool clicked = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Audio.isOn) {
			if (vrplayer.activeSelf) {
				vrplayer.GetComponent<AudioListener> ().enabled = true;
			}
			if (player.activeSelf) {
				player.GetComponent<AudioListener> ().enabled = true;
			}
		} else {
			if (vrplayer.activeSelf) {
				vrplayer.GetComponent<AudioListener> ().enabled = false;
			}
			if (player.activeSelf) {
				player.GetComponent<AudioListener> ().enabled = false;
			}
		}

		if (fullscreen.isOn) {
			Screen.SetResolution (1920, 1080, true);
		} else {
			Screen.SetResolution (1920, 1080, false);
		}
		if (canpause) {
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
	
	}

	public void OnClick()
	{
		SceneManager.LoadScene ("Main Menu");	
	}
	public void OnClickOptions()
	{
		OptionsMenu.SetActive (true);
		Options.SetActive (false);
		exit.SetActive (false);
	}
	public void X()
	{
		OptionsMenu.SetActive (false);
		Options.SetActive (true);
		exit.SetActive (true);
	}

}
