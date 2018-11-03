using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlay : MonoBehaviour {

    public GameObject Menu;
    public GameObject howToPlay;
    public GameObject credits;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Credits()
    {
        Menu.SetActive(false);
        credits.SetActive(true);
    }

    public void BackCredits()
    {
        Menu.SetActive(true);
        credits.SetActive(false);
    }

    public void HowTo()
    {
        howToPlay.SetActive(true);
        Menu.SetActive(false);
    }

    public void BackHowTo()
    {
        howToPlay.SetActive(false);
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
