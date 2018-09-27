using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class PlayerTank : MonoBehaviour
{

    public rotateTurret Turret;

    //Referencia ao playerHUD
    private PlayerHUD playerHUD;

    /// <Rewired>
    private Player rewPlayer;
    public int _playerNumber;
    /// </Rewired>



    /// <Variaveis>
    //Imagem da base do tank
    public Sprite _baseSprite;

    private SpriteRenderer sprtRendBase;

    //Velocidade do jogador se mover
    public float _speed;
    //Velocidade do jogador virar a base do tank
    public float _rotationSpeed;
    //Angulho para rotação da torre
    private  float _angle;
    //Vida inicial do jogador
    public int _life;
    //Contador de comida
    public int _foodCount = 0;
    /// </Variaveis>


    ///Vetores
    //Vetor para a base do tank
    Vector3 basePosition;
    //Vetor para a torre do tank
    Vector3 baseRotation;
    //Referencia as posições do player
    Transform playerTransform;

    ///Componentes
    //Componente de rigidbody do player
    public Rigidbody2D playerRb;


	// Use this for initialization
	void Start ()
    {
        rewPlayer = ReInput.players.GetPlayer(_playerNumber);



        sprtRendBase = GetComponentInChildren<SpriteRenderer>();



        CreateTank();

        playerRb = GetComponent<Rigidbody2D>();
        playerTransform = transform;

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

        if (Input.GetMouseButton(0))
         { Turret.Shoot(); }
    }

   void rotate()
    {
        ///Futuramente: Deixar a rotação com o Joystick, no analógico direito
        
        ///Rotação
        //Direita
        if (rewPlayer.GetButton("TurnRight"))
        {
            baseRotation.z -= _rotationSpeed;
        }
        //Esquerda
        if (rewPlayer.GetButton("TurnLeft"))
        {
            baseRotation.z += _rotationSpeed;
        }

        playerTransform.rotation = Quaternion.Euler(baseRotation);
    }

    void move()
    {
        ///Futuramente: Deixar o movimento com o Joystick, no analógico direito

        //
        if (rewPlayer.GetButton("MoveFront"))
        {
            
            playerRb.MovePosition(playerTransform.position + playerTransform.right * _speed * Time.deltaTime);
        }

        //
        if (rewPlayer.GetButton("MoveBack"))
        {
            
            playerRb.MovePosition(playerTransform.position - playerTransform.right * _speed * Time.deltaTime);
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
            _foodCount += 1;

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
    
    public void CreateTank()
    {
        //Imagem da base
        sprtRendBase.sprite = TankSettings.tankInfo[_playerNumber].baseTank._BodySprite;
        
        //Velocidade
        _speed = TankSettings.tankInfo[_playerNumber].baseTank._speed;

        //Vida
        _life = TankSettings.tankInfo[_playerNumber].baseTank._life;

        Debug.Log("TO TENTANDO CARALHOOOOOOOOO");
        //Informações da torre
        Turret.DefineTurret(TankSettings.tankInfo[_playerNumber].turret);
        
    }
}


