using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController>
{
    public GameObject _pauseMenuUi;


    //Se o jogo estiver pausado ou não
    public bool _pausedGame = false;
    //Variável para ver quantos jogadores existem em cena
    private int alivePlayers;
    public AudioController _sfx;

    public Animator _canvasAnim;
	
	void Start ()
    {
        //A variavel faz a contagem de quantos objetos na cena temos com a tag Player
        alivePlayers = GameObject.FindGameObjectsWithTag("Player").Length;


        StartCoroutine(StartGame());
       
        
    }
	

   public void AllFood()
   {
        SceneManager.LoadScene("Gameplay");
   }

   public void DeadPlayer()
   {
        //Retirando um player quando morre
        alivePlayers--;

        //Verificando se a quantidade de jogadores for menor que ou igual 1, reinicia a cena
        if (alivePlayers <= 1)
        {
            StartCoroutine(BeginGame());
            
        }
   }

   public void PauseGame()
   {

        _pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        _pausedGame = true;
        _sfx.Playsound(4, 0, false);
   }

   public void ResumeGame()
   {
        _pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        _pausedGame = false;
        _sfx.Playsound(4, 0, false);
    }

   public void QuitMenu()
   {
        Time.timeScale = 1f;
        _sfx.Playsound(4, 0, false);
        SceneManager.LoadScene("Menu");

   }

   public void ChooseTank()
   {
        Time.timeScale = 1f;
        _sfx.Playsound(4, 0, false);
        SceneManager.LoadScene("ChooseTank");
   }

    IEnumerator BeginGame()
    {
        SceneManager.LoadScene("Gameplay");
        _canvasAnim.SetBool("_gameOn", false);
        yield return new WaitForSeconds(2f);
        
    }

    IEnumerator StartGame()
    {
        _canvasAnim.SetBool("_gameOn", false);
        yield return new WaitForSeconds(2f);
        _canvasAnim.SetBool("_gameOn", true);
    }
   
}
