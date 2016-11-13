using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class PurchaseEquip : MonoBehaviour
{
    [Serializable]
    public class PurchaseList
    {
        public string skinName;
        public int skinNum;
        public int skinPrice;
        public int Purchased = 0;
        public int Equiped = 0;
    }
    public List<PurchaseList> skinList;

    public GameObject button;

    public Text ticketCounter;
    public Text skinName;

	public int firstload;

    int currentTickets;

    public int equipedSkin;

    public Sprite priceMat;
    public Sprite equipMat;
    public Sprite equipedMat;

    WeaponSelector weaponSelector;

    // Use this for initialization
    void Start()
    {
		currentTickets = PlayerPrefs.GetInt ("TotalTicket");
		firstload = PlayerPrefs.GetInt ("FirstLoad");

        weaponSelector = GetComponent<WeaponSelector>();
		for (int i = 0; i < (weaponSelector.weaponSkins.Count); i++) {
			skinList.Add (new PurchaseList ());
			GameObject skin = weaponSelector.weaponSkins [i];
			SkinInfo skinInfo = skin.GetComponent<SkinInfo> ();
			skinList [i].skinName = skinInfo.skinName;
			skinList [i].skinNum = i;
			skinList [i].skinPrice = skinInfo.price;
			skinList [i].Equiped = PlayerPrefs.GetInt (skinList [i].skinName + "Equiped"); 
			skinList [i].Purchased = PlayerPrefs.GetInt (skinList [i].skinName + "Purchased"); 
		}
		skinList [0].Purchased = 1;
		PlayerPrefs.SetInt (skinList[0].skinName + "Purchased", 1); 
		if (firstload == 0) {
			skinList [0].Equiped = 1;
			PlayerPrefs.SetInt (skinList [0].skinName + "Equiped", 1); 
			PlayerPrefs.SetInt ("FirstLoad", 1);
			firstload = 1;
		}

    }

	void OnApplicationQuit()
	{
		PlayerPrefs.SetInt("TotalTicket", currentTickets);
	}



    // Update is called once per frame
    void Update()
    {

		if (Input.GetKeyDown (KeyCode.Insert)) {
			PlayerPrefs.DeleteAll ();
			int equipedSkin = 1000;
		}

        ticketCounter.text = currentTickets.ToString();
        skinName.text = skinList[weaponSelector.viewedWeapon].skinName;
		if (skinList[weaponSelector.viewedWeapon].Purchased == 1 && skinList[weaponSelector.viewedWeapon].Equiped == 1)
        {
//            button.GetComponent<Button>().interactable = false;
            button.GetComponent<Image>().sprite = equipedMat;
            button.GetComponentInChildren<Text>().text = "";
        }
		else if (skinList[weaponSelector.viewedWeapon].Purchased == 1 && skinList[weaponSelector.viewedWeapon].Equiped == 0)
        {
//			button.GetComponent<Button>().interactable = true;
            button.GetComponent<Image>().sprite = equipMat;
            button.GetComponentInChildren<Text>().text = "";
        }
        else
        {
//            button.GetComponent<Button>().interactable = true;
            button.GetComponent<Image>().sprite = priceMat;
            button.GetComponentInChildren<Text>().text = skinList[weaponSelector.viewedWeapon].skinPrice.ToString();
        }
    }

    public void PurchaseEquipHandle()
    {
		if (currentTickets >= skinList [weaponSelector.viewedWeapon].skinPrice) {
			if (skinList [weaponSelector.viewedWeapon].Purchased == 0 && skinList [weaponSelector.viewedWeapon].Equiped == 0) {
				currentTickets -= skinList [weaponSelector.viewedWeapon].skinPrice;
				skinList [weaponSelector.viewedWeapon].Purchased = 1;
				PlayerPrefs.SetInt (skinList [weaponSelector.viewedWeapon].skinName + "Purchased", 1); 
			} else if (skinList [weaponSelector.viewedWeapon].Purchased == 1 && skinList [weaponSelector.viewedWeapon].Equiped == 0) {
				for (int i = 0; i < skinList.Count; i++) {
					skinList [i].Equiped = 0;
					PlayerPrefs.SetInt (skinList [i].skinName + "Equiped", 0); 
				}
				skinList [weaponSelector.viewedWeapon].Equiped = 1;
				PlayerPrefs.SetInt (skinList [weaponSelector.viewedWeapon].skinName + "Equiped", 1);
				equipedSkin = skinList [weaponSelector.viewedWeapon].skinNum;
			}
		}
    }
}
