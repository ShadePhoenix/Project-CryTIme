using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextFlash : MonoBehaviour {

	public RawImage standby;
	public float time;

	public bool stop;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

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
