using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class PlayerTank : MonoBehaviour {

    //Referencia ao playerHUD
    private PlayerHUD playerHUD;

    /// <Rewired>
    private Player rewPlayer;
    public int _playerNumber;
    /// </Rewired>

    /// <Objetos>
    //Objeto para o tiro do jogador
    public GameObject shoot;
    /// </Objetos>

    /// <Variaveis>
    //Velocidade do jogador se mover
    public float speed;
    //Velocidade do jogador virar a base do tank
    public float rotationSpeed;
    //Velocidade para o tiro
    public float fireRate;
    //Angulho para rotação da torre
    private  float angle;
    //Dano inicial do jogador
    public int _damage = 10;
    //Vida inicial do jogador
    public int _life = 200;
    //Contador de comida
    public int foodCount = 0;
    /// </Variaveis>


    ///Vetores
    //Vetor para o tiro com rotação
    Vector3 shootRotation;
    //Vetor para a base do tank
    Vector3 basePosition;
    //Vetor para a torre do tank
    Vector3 baseRotation;
    //Posição onde o tiro irá ser instanciado
    public Transform shootSpawn;
    //Referencia as posições do player
    Transform playerTransform;

    ///Componentes
    //Componente de rigidbody do player
    public Rigidbody2D playerRb;


	// Use this for initialization
	void Start ()
    {
        rewPlayer = ReInput.players.GetPlayer(_playerNumber);

        

        playerRb = GetComponent<Rigidbody2D>();
        playerTransform = transform;
        shootRotation = baseRotation;


        var HUDs = FindObjectsOfType<PlayerHUD>();

        foreach (var hud in HUDs)
        {
            if(hud.playerNumerHUD == _playerNumber)
            {
                playerHUD = hud;
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
 
        rotate();

        move();

        Shoot();

    }

   void rotate()
    {
        ///Futuramente: Deixar a rotação com o Joystick, no analógico direito
        
        ///Rotação
        //Direita
        if (rewPlayer.GetButton("Turnright"))
        {
            baseRotation.z -= rotationSpeed;
        }
        //Esquerda
        if (rewPlayer.GetButton("TurnLeft"))
        {
            baseRotation.z += rotationSpeed;
        }

        playerTransform.rotation = Quaternion.Euler(baseRotation);
    }

    void move()
    {
        ///Futuramente: Deixar o movimento com o Joystick, no analógico esquerdo

        //
        if (rewPlayer.GetButton("MoveFront"))
        {
            
            playerRb.MovePosition(playerTransform.position + playerTransform.right * speed * Time.deltaTime);
        }

        //
        if (rewPlayer.GetButton("MoveBack"))
        {
            
            playerRb.MovePosition(playerTransform.position - playerTransform.right * speed * Time.deltaTime);
        }
    }

    void Shoot()
    {
        fireRate += 0.1f;

        ///Furutamente: Deixar esse input para o Joystick, ou seja aqui seria o R1 para atirar.

        //Se apertar click do mouse e o tempo for menor que 2 segundos, atira
        //
        if (rewPlayer.GetButton("Shoot") && fireRate >= 2.0f)
        {
            GameObject tempBullet = Instantiate(shoot, shootSpawn.position, shootSpawn.rotation);
            fireRate = 0;

            Destroy(tempBullet, 4.0f);
            
        }
    }



    void OnCollisionEnter2D(Collision2D other)
    {
        //Verifica se a tag é food
        if (other.collider.CompareTag("Food"))
        {
            //Verifica se o objeto é do tipo coletável
            Collectable collectable = other.gameObject.GetComponent<Collectable>();

            //Chamando a função para ativar o toggle, para ativa o tipo de comida que foi coletado
            playerHUD.Collected(collectable.foodType);

            //Contando as comidas
            foodCount += 1;

            //Destruindo o objeto
            Destroy(other.gameObject);
        }
    }

    //Função de dano contra os tanks
    public void ApplyDamage(int damage)
    {
        _life -= damage;

        if(_life <= 0)
        {
            //O gerenciador chama a função para verificar se só existe um jogador vivo e reinicia o jogo
            GameController.Instance.DeadPlayer();

            Destroy(gameObject);
        }
    }

    public void CountFood(int food)
    {
        if(food >= 5)
        {
            GameController.Instance.AllFood();
        }
    }
    

}


