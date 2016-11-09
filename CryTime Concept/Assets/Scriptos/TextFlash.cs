using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextFlash : MonoBehaviour {

	public RawImage standby;
	public float time;
	public GameObject player;

	public bool stop;
	bool start = true;

	// Use this for initialization
	void Start () {
	}



	// Update is called once per frame
	void Update () {

		if (player.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsTag ("Moving")) {
			standby.gameObject.SetActive (true);
		} else {
			standby.gameObject.SetActive (false);
		}
		
	}

	public IEnumerator textflash(RawImage img)
	{
		while (!stop) {
			yield return new WaitForSeconds (time);
			img.gameObject.SetActive (false);
			yield return new WaitForSeconds (time);
			img.gameObject.SetActive (true);
		}
	}


}
