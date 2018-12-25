using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController>
{
    public GameObject _pauseMenuUi;
    public RicochetBullet _ricoBullet;


    public GameObject _ricoExplo;

    //Se o jogo estiver pausado ou não
    public bool _pausedGame = false;
    //Variável para ver quantos jogadores existem em cena
    private int alivePlayers;

	
	void Start ()
    {
        //A variavel faz a contagem de quantos objetos na cena temos com a tag Player
        alivePlayers = GameObject.FindGameObjectsWithTag("Player").Length;

        _ricoBullet.ExplosionEvent += OnExplosion;
    }
	
	
    void Update ()
    {
        
	}

    void OnDisable()
    {
        _ricoBullet.ExplosionEvent -= OnExplosion;
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
            SceneManager.LoadScene("Gameplay");
        }
   }

   public void PauseGame()
   {
        _pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        _pausedGame = true;
   }

   public void ResumeGame()
   {
        _pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        _pausedGame = false;
   }

   public void QuitMenu()
   {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
   }

   public void ChooseTank()
   {
        Time.timeScale = 1f;
        SceneManager.LoadScene("ChooseTank");
   }

   public void OnExplosion(bool explosion)
   {
        Debug.Log("O evento deu bom :D");
        //Aqui, tem que instanciar a particula na posição da bala, dizer que a explosão aconteceu
        GameObject tempExplo = Instantiate(_ricoExplo, _ricoBullet.transform.position, _ricoBullet.transform.rotation);
        explosion = false;
        _ricoBullet._onExplosion = explosion;
        
   }

   
   
}
