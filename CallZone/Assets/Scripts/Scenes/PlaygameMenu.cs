using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlaygameMenu : MonoBehaviour
{

    public Animator sceneAnim;

    public AudioController _sfx;

    public TextMeshProUGUI _load;
    public Animator _loadAnim;
    public Button _readyButton1;
    public Button _readyButton2;
    public GameObject _buttonsSelections;
    public GameObject _buttonsSelections2;

    private bool _readyP1 = false;
    private bool _readyP2 = false;

    void Start()
    {
        //Musica de menu com loop
        _sfx.VolumeController(1, 0.5f);
        _sfx.Playsound(1, 0, true);
        _load.text = " ";
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
        yield return new WaitForSeconds(2f);
        _load.text = "Loading...";
        _loadAnim.SetBool("load", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReadyButtonP1()
    {
        _sfx.Playsound(0, 2, false);
        _readyP1 = true;
        _readyButton1.enabled = false;
        _buttonsSelections.SetActive(false);
    }
    public void ReadyButtonP2()
    {
        _sfx.Playsound(0, 2, false);
        _readyP2 = true;
        _readyButton2.enabled = false;
        _buttonsSelections2.SetActive(false);
    }
}
