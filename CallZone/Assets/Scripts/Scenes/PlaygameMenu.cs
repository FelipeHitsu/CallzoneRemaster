using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaygameMenu : MonoBehaviour {

    public AudioController soundController;

    public void Play()
    {
        soundController.Playsound(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
    }
}
