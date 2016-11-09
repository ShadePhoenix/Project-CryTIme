using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasRes : MonoBehaviour {

	public Camera VRcam;
	public GameObject HealthUI;
	public float x;
	public float y;
	public float z;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (VRcam.gameObject.activeSelf) {
			HealthUI.GetComponent<RectTransform>().position = new Vector3 (x, y, z);
		}
	}
}
