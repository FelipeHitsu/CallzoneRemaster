using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlay : MonoBehaviour {

    public GameObject Menu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Credits()
    {
        Menu.SetActive(false);
    }
    public void BackCredits()
    {
        Menu.SetActive(true);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("ChooseTank");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
