using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlay : MonoBehaviour {

    public GameObject Menu;
    public GameObject howToPlay;
    public GameObject credits;
    public Animator _AnimPlay;
    public AudioController _sfx;

    //Abre os créditos
    public void Credits()
    {
        _sfx.Playsound(0, 1, false);
        Menu.SetActive(false);
        credits.SetActive(true);
        
        
    }

    //Volta pro menu
    public void BackCredits()
    {
        _sfx.Playsound(0, 2, false);
        Menu.SetActive(true);
        credits.SetActive(false);
        
    }

    //Abre como jogar
    public void HowTo()
    {
        _sfx.Playsound(0, 1, false);
        howToPlay.SetActive(true);
        Menu.SetActive(false);
        
    }
    //Volta pro menu
    public void BackHowTo()
    {
        _sfx.Playsound(0, 2, false);
        howToPlay.SetActive(false);
        Menu.SetActive(true);
       
    }

    //Começa o jogo
    public void StartGame()
    {
        //Colocar a animação pra tocar aqui 
        StartCoroutine(ChooseMenu());
    }

    //Sai do jogo
    public void QuitGame()
    {
        _sfx.Playsound(0, 3, false);
        Application.Quit();
    }

    //Animação de troca de cena
    IEnumerator ChooseMenu()
    {
        _sfx.Playsound(0, 0, false);
        _AnimPlay.SetBool("playGame", true);
        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadScene("ChooseTank");
    }
}
