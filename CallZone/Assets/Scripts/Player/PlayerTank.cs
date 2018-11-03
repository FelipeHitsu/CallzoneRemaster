using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;


public class PlayerTank : MonoBehaviour
{
    ///<Animações>
    public Animator energyAnim;
    ///</Animações>


    /// <Eventos>
    public delegate void  DamageDelegate(float currentLife);
    public event DamageDelegate DamageEvent;

    public delegate void EnergyDelegate(float totalFood);
    public event EnergyDelegate EnergyEvent;

   
        
    /// </Eventos>

    ///<Áudio>
    public AudioController _sfx;
    ///</Áudio>

    ///<Particulas>
    //Particulas de coletando objeto
    public GameObject _collectParticle;
    //Particula de prize por coletar
    public GameObject _collectPrize;
    ///</Particulas>

    /// <Torre>
    public rotateTurret Turret;
    /// </Torre>

    public Transform prize;

    /// <Rewired>
    private Player rewPlayer;
    public int _playerNumber;
    /// </Rewired>

    /// <Variaveis>
    //Velocidade do jogador se mover
    private  float _speed;
    //Velocidade do jogador virar a base do tank
    private float _rotationSpeed = 3f;
    //Angulho para rotação da torre
    private  float _angle;
    //Vida inicial do jogador maxima e atual
    private int _maxLife;
    private int _life;
    //Contador de comida
    private int _foodCount = 0;
    //Energia maxima e atual
    private float _maxEnergy;
    private float _energy;
    /// </Variaveis>


    ///Vetores
    //Vetor para a base do tank
    Vector3 basePosition;
    //Vetor para a torre do tank
    Vector3 baseRotation;

    ///<Componentes>
    //Componente de rigidbody do player
    [HideInInspector]
    public Rigidbody2D playerRb;
    //Sprite para ser alterada do tank
    private SpriteRenderer sprtRendBase;
    //
    public GameController _gameController;
    ///</Componentes>

    
    void Start ()
    { 

        rewPlayer = ReInput.players.GetPlayer(_playerNumber);

        sprtRendBase = GetComponentInChildren<SpriteRenderer>();

        CreateTank();

        playerRb = GetComponent<Rigidbody2D>();

        

    }
	
	// Update is called once per frame
	void Update ()
    {
        VerifyEnergy(_energy);
        rotate();
        move();

        //Input R1 do joystick
        if (rewPlayer.GetButton("Shoot"))
        {
            //Chamando a função de tiro
            Turret.Shoot();
        }

        if(Input.GetKey(KeyCode.R))
        {
            _gameController.PauseGame();
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            _gameController.ResumeGame();
        }
    }

   void rotate()
    {
        
        
        ///Rotação
        //Direita, com joystick
        if (rewPlayer.GetButton("TurnRight"))
        {
            baseRotation.z -= _rotationSpeed;
        }
        //Esquerda, com joystick
        else if (rewPlayer.GetButton("TurnLeft"))
        {
            baseRotation.z += _rotationSpeed;
        }

        transform.rotation = Quaternion.Euler(baseRotation);
    }

    void move()
    {

        _sfx.VolumeController(0, 0.1f);


        //Frente, com joystick
        if (rewPlayer.GetButton("MoveFront"))
        {
            //Clip, source, bool
            if (_sfx.AudioIsPlaying(0, 1))
            {
                _sfx.StopSound(0);
                _sfx.Playsound(0, 0, false);
            }
            playerRb.MovePosition(transform.position + transform.right * _speed * Time.deltaTime);
        }

        //Trás, com joystick
        else if (rewPlayer.GetButton("MoveBack"))
        {
            if (_sfx.AudioIsPlaying(0, 1))
            {
                _sfx.StopSound(0);
                _sfx.Playsound(0, 0, false);
            }

            playerRb.MovePosition(transform.position - transform.right * _speed * Time.deltaTime);
        }

        if (!_sfx.AudioIsPlaying(0, 0))
        {
            _sfx.Playsound(0, 1, true);
        }
    }

    public void VerifyEnergy(float energy)
    {
        if (energy >= _maxEnergy)
            energyAnim.SetBool("energyIsFull", true);
        else
            energyAnim.SetBool("energyIsFull", false);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        //Verifica se a tag é food
        if (other.collider.CompareTag("Food"))
        {
            GameObject tempPrize = Instantiate(_collectPrize, prize.position, transform.rotation);
            Destroy(tempPrize, .15f);

            GameObject tempCollect = Instantiate(_collectParticle, transform.position, Quaternion.identity);
            Destroy(tempCollect, 1.0f);

            //Som coletando a comida
            _sfx.Playsound(3, 0, false);

            //Verifica se o objeto é do tipo coletável
            Collectable collectable = other.gameObject.GetComponent<Collectable>();

            //Contando as comidas
            _foodCount += 1;

            //Setando o valor de energia de cada comida
            GetEnergy(collectable.foodEnergy);

            //Destruindo o objeto
            Destroy(other.gameObject);
        }

        
    }

    //Função de dano contra os tanks
    public void ApplyDamage(int damage, int numberOfWho)
    {
        //Aplicando o dano
       _life -= damage;

        //Som do dano
        _sfx.Playsound(2, 0, false);

        //Chamada do evento de dano
        if (DamageEvent != null)
        {
            DamageEvent.Invoke((float)_life / _maxLife);
        }

        if(_life <= 0)
        {
            //O gerenciador chama a função para verificar se só existe um jogador vivo e reinicia o jogo
            GameController.Instance.DeadPlayer();

            Destroy(gameObject);
        }
    }

    //Função que chama o evento para coletar energia
    public void GetEnergy(float energy)
    {
        _energy += energy;

        if (EnergyEvent != null)
            EnergyEvent.Invoke(_energy / _maxEnergy);

    }

   

    //Isso aqui vai servir pra dar respawns caso as comidas acabem
    public void CountFood(int food)
    {
        if(food >= 5)
        {
            Debug.Log("Comidas full!" + food);
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
        _maxLife = TankSettings.tankInfo[_playerNumber].baseTank._life;
        _life = _maxLife;

        //Energia
        _maxEnergy = 200;

        //Informações da torre
        Turret.DefineTurret(TankSettings.tankInfo[_playerNumber].turret);
        
    }
}


