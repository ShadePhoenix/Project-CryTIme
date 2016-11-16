using UnityEngine;
using System.Collections;

public class UpdateScreen : MonoBehaviour {

	Renderer renderer;

	// Use this for initialization
	void Start () {

		renderer = GetComponent<Renderer> ();
		DynamicGI.UpdateMaterials (renderer);
	
	}
	
	// Update is called once per frame
	void Update () {

		DynamicGI.UpdateMaterials (renderer);
	
	}
}
