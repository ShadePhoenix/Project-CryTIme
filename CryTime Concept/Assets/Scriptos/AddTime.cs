using UnityEngine;
using System.Collections;

public class AddTime : MonoBehaviour {
	
	public GameObject[] Stage1;
	public int Stage1Time;
	public GameObject[] Stage2;
	public int Stage2Time;
	public GameObject[] Stage3;
	public int Stage3Time;
	public CountDown time;


	bool com1;
	bool done1 = false;
	bool com2;
	bool done2 = false;
	bool com3;
	bool done3 = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (!done1) {
			foreach (GameObject enemy in Stage1) {
				if (enemy.activeSelf == true) {
					com1 = false;
					break;
				} else {
					com1 = true;
				}
			}
		}
		if (!done2) {
			foreach (GameObject enemy in Stage2) {
				if (enemy.activeSelf == true) {
					com2 = false;
					break;
				} else {
					com2 = true;
				}
			}
		}
		if (!done3) {
			foreach (GameObject enemy in Stage3) {
				if (enemy.activeSelf == true) {
					com3 = false;
					break;
				} else {
					com3 = true;
				}
			}
		}

		if (com1) {
			done1 = true;
			com1 = false;
			time.count = time.count + Stage1Time;
		}
		if (com2) {
			done2 = true;
			com2 = false;
			time.count = time.count + Stage2Time;
		}
		if (com3) {
			done3 = true;
			com3 = false;
			time.count = time.count + Stage3Time;
		}
	
	}
}
