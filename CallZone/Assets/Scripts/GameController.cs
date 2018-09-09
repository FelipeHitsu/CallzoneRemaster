using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController>
{
    
    //Variável para ver quantos jogadores existem em cena
    private int alivePlayers;

	// Use this for initialization
	void Start ()
    {
        //A variavel faz a contagem de quantos objetos na cena temos com a tag Player
        alivePlayers = GameObject.FindGameObjectsWithTag("Player").Length;
        

        
    }
	
	// Update is called once per frame
	void Update ()
    {
		//nada aqui
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

   
}
