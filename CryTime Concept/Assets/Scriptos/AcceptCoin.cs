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
		//checks if coin collides with coin collector
		if (col.collider.tag == "Coin") {
			//if yes, it removes the coin
            col.gameObject.SetActive(false);
			//it then calls a function in the Continue script to continue the gam
            con.Yes();
		}
	}

}
