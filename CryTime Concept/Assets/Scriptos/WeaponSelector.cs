using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponSelector : MonoBehaviour
{
    public List<GameObject> weaponSkins;
    int numberOfSkins;
    float radius;
    public List<GameObject> weaponWheel;
    public Transform spawnPoint;
    public float rotationSpeed = 1;
    GameObject weaponWheelItem;
    GameObject selectedWeapon;
    Quaternion startRotation;
    bool doRotate = false;
    public int viewedWeapon;

    void Start()
    {
        startRotation = spawnPoint.rotation;
    }

    public void SpawnSkins()
    {

        numberOfSkins = weaponSkins.Count;
        radius = numberOfSkins * 11;
        for (int i = 0; i < numberOfSkins; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfSkins;
            Vector3 localPos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            weaponWheel.Add(weaponWheelItem = Instantiate(weaponSkins[i], spawnPoint) as GameObject);
            weaponWheelItem.transform.localPosition = localPos;
        }
        doRotate = true;
    }

    public void PurchaseEquip()
    {
        selectedWeapon = weaponWheel[viewedWeapon];
    }

    public void RightRotate()
    {
        viewedWeapon = (viewedWeapon + 1) % numberOfSkins;
        Debug.Log(viewedWeapon);
        StopAllCoroutines();
        startRotation.eulerAngles = new Vector3(0, 360 / numberOfSkins + startRotation.eulerAngles.y, 0);
        StartCoroutine(Rotate(0));
    }
    public void LeftRotate()
    {
        if (viewedWeapon == 0)
        {
            viewedWeapon = numberOfSkins - 1;
        }
        else
        {
            viewedWeapon = (viewedWeapon - 1) % numberOfSkins;
        }
        Debug.Log(viewedWeapon);
        StopAllCoroutines();
        startRotation.eulerAngles = new Vector3(0, -360 / numberOfSkins + startRotation.eulerAngles.y, 0);
        StartCoroutine(Rotate(0));
    }

    public void ExitArmory()
    {
        doRotate = false;
        for (int i = 0; i < numberOfSkins; i++)
        {
            Destroy(weaponWheel[i]);
        }
        weaponWheel.RemoveRange(0, numberOfSkins);
        GetComponent<MenuScript>().armoryMenu.SetActive(false);
        GetComponent<MenuScript>().mainMenu.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (doRotate)
        {
            for (int i = 0; i < numberOfSkins; i++)
            {
                weaponWheel[i].transform.localEulerAngles += new Vector3(0, rotationSpeed, 0);
            }
        }
    }

    IEnumerator Rotate(float rotationAmount)
    {
        Quaternion finalRotation = Quaternion.Euler(0, rotationAmount, 0) * startRotation;

        while (spawnPoint.rotation != finalRotation)
        {
            spawnPoint.rotation = Quaternion.Lerp(spawnPoint.rotation, finalRotation, Time.deltaTime * 10);
            yield return 0;
        }
    }
}
