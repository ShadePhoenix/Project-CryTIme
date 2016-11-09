using UnityEngine;
using System.Collections;

public class AcceptCoin : MonoBehaviour {

    public Continue con;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.collider.tag == "Coin") {
            Debug.Log("hi");
            col.gameObject.SetActive(false);
            con.Yes();
		}
	}

}
