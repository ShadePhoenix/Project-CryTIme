using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PCorVR : MonoBehaviour {

	public static bool vrON;
	public Canvas UI;
	public Camera PCcam;
	public GameObject[] objects;


	// Use this for initialization
	void Start () {
		UnityEngine.VR.VRSettings.enabled = true;

		if (UnityEngine.VR.VRSettings.enabled)
		{
            foreach (GameObject obj in objects) {
				if (obj.layer == 10) {
					Debug.Log ("hih");
					obj.gameObject.SetActive (true);
				}
			}
			UI.renderMode = RenderMode.ScreenSpaceCamera;
			PCcam.gameObject.SetActive (false);
		} 
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void IFVR()
	{
		if (transform.GetComponent<Dropdown> ().value == 0) {
			vrON = false;
		} else {
			vrON = true;
		}
	}

}
