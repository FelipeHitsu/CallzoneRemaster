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
    ///</Particulas>

    /// <Torre>
    public rotateTurret Turret;
    /// </Torre>



    /// <Rewired>
    private Player rewPlayer;
    public int _playerNumber;
    /// </Rewired>

    /// <Variaveis>
    //Velocidade do jogador se mover
    private  float _speed;
    //Velocidade do powerUp com valor 0
    private float _speedPU = 1;
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
    //Pra saber se o jogador usou o powerUp ou não
    private bool _powerUpisOn;
    //Quanto tempo o powerUp vai ficar ativo
    private float _powerUpTimer = 5f;
    //Line para o powerUp de velocidade
    private TrailRenderer _speedLiner;
    //Particula de powerUp
    public GameObject _speedPtc;
    /// </Variaveis>


    ///Vetores
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    //Vetor para a base do tank
    private Vector3 basePosition;
    //Vetor para a torre do tank
    private Vector3 baseRotation;

    ///<Componentes>
    //Componente de rigidbody do player
    [HideInInspector]
    public Rigidbody2D playerRb;
    //Sprite para ser alterada do tank
    private SpriteRenderer sprtRendBase;
    //Controle do jogo
    public GameController _gameController;
    ///</Componentes>

    
    void Start ()
    { 

        rewPlayer = ReInput.players.GetPlayer(_playerNumber);

        sprtRendBase = GetComponentInChildren<SpriteRenderer>();

        CreateTank();

        playerRb = GetComponent<Rigidbody2D>();

        _speedLiner = GetComponent<TrailRenderer>();
        _speedLiner.enabled = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
        VerifyEnergy(_energy);
        rotate();
        move();


        
        if (_powerUpisOn)
        {

            //Habilita a linha
            _speedLiner.enabled = true;

            //Contagem de tempo
            _powerUpTimer -= Time.deltaTime;
           
            //Se zerar, desativa a linha e volta velocidade normal
            if (_powerUpTimer <= 0)
            {
                _powerUpisOn = false;
                _speedPU = 1;
                _speedLiner.enabled = false;
                _powerUpTimer = 5f;
            }
        }



        //Apertar X, para o powerUp
        if (rewPlayer.GetButton("PowerUp"))
        {
            //Chamando a função de powerup
            PowerUpSpeed(_energy);
        }

        //Input R1 do joystick
        if (rewPlayer.GetButton("Shoot"))
        {
            //Chamando a função de tiro
            Turret.Shoot();
        }

        //Apertar (triangulo) abri o menu
        if(rewPlayer.GetButton("Pause"))
        {
            _gameController.PauseGame();

        }

        if (_gameController._pausedGame)
        {
            //Apertar (quadrado) dentro do pause vai para a seleção de menu
            if (rewPlayer.GetButton("MenuSelection"))
            {
                _gameController.ChooseTank();
            }

            //Apertar (bolinha) dentro do pause vai volta para o jogo
            if (rewPlayer.GetButton("BackPause"))
            {
                _gameController.ResumeGame();
            }

            //Apertar (X) volta pro menu inicial do jogo
            if(rewPlayer.GetButton("Quit"))
            {
                _gameController.QuitMenu();
            }
        }
    }

   void rotate()
    {
        


       

        ////Direita, com joystick
        //if (rewPlayer.GetButton("TurnBaseRight"))
        //{
           
        //    baseRotation.z -= _rotationSpeed;
        //}
        ////Esquerda, com joystick
        //else if (rewPlayer.GetButton("TurnBaseLeft"))
        //{
            
        //    baseRotation.z += _rotationSpeed;
        //}
        
         
    }

    void move()
    {

        //Inputs para movimento, x e y
        float _x = Input.GetAxis("Horizontal");
        float _y = Input.GetAxis("Vertical");

        //Let's try agaaaainnnn............
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        moveVelocity = moveInput * _speed * _speedPU * Time.deltaTime;

        ////Inputs para rotação(VAI LA PRA TORRE ESSES INPUTS)
        //float _rX = Input.GetAxis("Right_Horizontal");
        //float _rY = Input.GetAxis("Right_Vertical");

        
       
        //Som de movimento
        _sfx.VolumeController(0, 0.1f);



        //Frente, com joystick
        if (rewPlayer.GetButton("Move"))
        {
            //Clip, source, bool
            if (_sfx.AudioIsPlaying(0, 1))
            {
                _sfx.StopSound(0);
                _sfx.Playsound(0, 0, false);
            }

            //Novo movimento com o ângulo do joystick
            playerRb.MovePosition(transform.position + moveInput);
            

            ////Rotação são os dois vetores de inputs
            //_rotationSpeed = Mathf.Atan2(_y, _x);

            ////Aplicando a rotação ao valor dos vetores
            //transform.rotation = Quaternion.Euler(0, 0, _rotationSpeed);


            //Movimento antigo
            //playerRb.MovePosition(transform.position + transform.right * _speed * _speedPU * Time.deltaTime);
        }

        ////Trás, com joystick
        //else if (rewPlayer.GetButton("MoveBack"))
        //{
        //    if (_sfx.AudioIsPlaying(0, 1))
        //    {
        //        _sfx.StopSound(0);
        //        _sfx.Playsound(0, 0, false);
        //    }

        //    //Novo movimento com o ângulo do joystick
        //    playerRb.MovePosition(transform.position - new Vector3(_x, 1) * _speed * _speedPU * Time.deltaTime);


        //    //Movimento antigo
        //    //playerRb.MovePosition(transform.position - transform.right * _speed * _speedPU * Time.deltaTime);
        //}

        if (!_sfx.AudioIsPlaying(0, 0))
        {
            _sfx.Playsound(0, 1, true);
        }
    }

    //Função que verifica a quantidade de energia que o jogador tem para usar o powerUp
    public void VerifyEnergy(float energy)
    {
        if (energy >= _maxEnergy)
        {
            
            energyAnim.SetBool("energyIsFull", true);
            
        }
        else
            energyAnim.SetBool("energyIsFull", false);
    }


    //Função que ativa o powerup(VAI SER PASSADO PRA PASSIVA COM CD ISSO AQUI)
    public void PowerUpSpeed(float energy)
    {
        //Se estiver ativo
        if(energy >= _maxEnergy)
        {
            //Instanciando a particula
            GameObject tempSpeedPtc = Instantiate(_speedPtc, transform.position, transform.rotation);
            Destroy(tempSpeedPtc, 1f);

            _energy = 0;
            _speedPU = 2.5f;
            _powerUpisOn = true;
            
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Verifica se a tag é food
        if (other.collider.CompareTag("Food"))
        {
            

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


