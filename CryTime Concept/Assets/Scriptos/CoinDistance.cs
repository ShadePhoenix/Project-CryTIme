using UnityEngine;
using System.Collections;

public class CoinDistance : MonoBehaviour {

	public SteamVR_TrackedObject trackedobj;
	Vector3 originalpos;

	bool grabbing;

	// Use this for initialization
	void Start () {

		originalpos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//this is a bunch of code that allows you to pick up coins without being
		//affected by time scale
		SteamVR_Controller.Device device = SteamVR_Controller.Input ((int)trackedobj.index);
		if (device.GetTouchDown (SteamVR_Controller.ButtonMask.Grip)) {
			float dist = Vector3.Distance (trackedobj.transform.position, transform.position);
			dist *= 100;
			if (dist <= 4) {
				grabbing = true;
			}

		}
		if (device.GetTouch (SteamVR_Controller.ButtonMask.Grip) && grabbing) {
			float dist = Vector3.Distance (trackedobj.transform.position, transform.position);
			dist *= 100;
			if (dist <= 4) {
				transform.position = trackedobj.transform.position;
			} else {
				grabbing = false;
			}
		}
	
	}

	void OnCollisionEnter(Collision col)
	{
		//checks to see if the coin hits the floor, if so it will be tp'd back 
		//this stops players from throwing coins away
		if (col.collider.tag == "Floor") {
			transform.position = originalpos;
		}
	}
}
