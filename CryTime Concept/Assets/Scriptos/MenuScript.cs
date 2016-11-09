using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    public GameObject mainMenu;
    public GameObject armoryMenu;

    void Start()
    {
        mainMenu.SetActive(true);
        armoryMenu.SetActive(false);
    }

    public void StartGame()
    {
		SceneManager.LoadScene ("Scene1");
    }

    public void Armory()
    {
        mainMenu.SetActive(false);
        armoryMenu.SetActive(true);
        GetComponent<WeaponSelector>().SpawnSkins();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
