using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaygameMenu : MonoBehaviour {

    public Animator sceneAnim;

    public AudioController soundController;

    public void Play()
    {
        soundController.Playsound(0, 0, false);

        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        sceneAnim.SetBool("isLoad", true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
