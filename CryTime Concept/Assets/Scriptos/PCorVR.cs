using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PCorVR : MonoBehaviour {

	public static bool vrON;
	public Canvas UI;
	public Camera PCcam;
	public GameObject[] objects;
	public CanvasScaler can;


	// Use this for initialization
	void Start () {
		UnityEngine.VR.VRSettings.enabled = true;

		if (!UnityEngine.VR.VRSettings.enabled)
		{
            foreach (GameObject obj in objects) {
				if (obj.layer == 10) {
					obj.gameObject.SetActive (false);
				}
			}
			UI.renderMode = RenderMode.ScreenSpaceOverlay;
			PCcam.gameObject.SetActive (true);
			can.referenceResolution = new Vector2 (800, 600);
		} 
	
	}
	
	// Update is called once per frame
	void Update () {
	}


}
