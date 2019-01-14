using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlay : MonoBehaviour {

    public GameObject Menu;
    public GameObject howToPlay;
    public GameObject credits;
    public Animator _AnimPlay;


    //Abre os créditos
    public void Credits()
    {
        Menu.SetActive(false);
        credits.SetActive(true);

        
    }

    //Volta pro menu
    public void BackCredits()
    {
        Menu.SetActive(true);
        credits.SetActive(false);
    }

    //Abre como jogar
    public void HowTo()
    {
        howToPlay.SetActive(true);
        Menu.SetActive(false);
    }
    //Volta pro menu
    public void BackHowTo()
    {
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
        Application.Quit();
    }

    //Animação de troca de cena
    IEnumerator ChooseMenu()
    {
        _AnimPlay.SetBool("playGame", true);
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("ChooseTank");
    }
}
