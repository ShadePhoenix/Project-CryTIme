using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShootToSkip : MonoBehaviour {

	public Text text;

	// Use this for initialization
	void Start () {
		StartCoroutine (wait ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator wait()
	{
		yield return new WaitForSecondsRealtime (7);
		text.gameObject.SetActive (true);
	}

}
