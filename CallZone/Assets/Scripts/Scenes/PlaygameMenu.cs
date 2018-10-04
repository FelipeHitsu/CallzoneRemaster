using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaygameMenu : MonoBehaviour {

    public AudioController soundController;
    public AudioClip onGame;

    public void Play()
    {
        //soundController.Playsound(onGame);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
    }
}
