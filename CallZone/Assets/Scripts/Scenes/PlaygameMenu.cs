using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaygameMenu : MonoBehaviour {

    public Animator sceneAnim;

    public AudioController _soundController;


    public Button _readyButton1;
    public Button _readyButton2;
    public GameObject _buttonsSelections;
    public GameObject _buttonsSelections2;

    private bool _readyP1 = false;
    private bool _readyP2 = false;

    void Start()
    {
        _soundController.VolumeController(1, 0.5f);
        _soundController.Playsound(1, 0, true);
    }

    void Update()
    {
        if (_readyP1 && _readyP2)
        {

            StartCoroutine(PlaySound());

            StartCoroutine(LoadScene());
        }
    }
        
    
    IEnumerator PlaySound()
    {

        yield return new WaitForSeconds(2.5f);
    }

    IEnumerator LoadScene()
    {
        sceneAnim.SetBool("isLoad", true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReadyButtonP1()
    {
        _soundController.Playsound(0, 1, false);
        _readyP1 = true;
        _readyButton1.enabled = false;
        _buttonsSelections.SetActive(false);
    }
    public void ReadyButtonP2()
    {
        _soundController.Playsound(0, 1, false);
        _readyP2 = true;
        _readyButton2.enabled = false;
        _buttonsSelections2.SetActive(false);
    }
}
