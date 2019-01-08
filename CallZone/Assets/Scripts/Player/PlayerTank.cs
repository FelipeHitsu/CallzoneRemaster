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
    //Particula de fumaça do tank
    public GameObject _smokePtc;
    //Particula de powerUp
    public GameObject _speedPtc;
    //Line para o powerUp de velocidade
    public TrailRenderer _speedLiner;
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
    private float _speedPU;
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
    //Pra saber se o jogador usou o powerUp de velocidade ou não
    private bool _powerUpisOn;
    private bool _activeSpeed;
    //Quanto tempo o powerUp de speed vai ter de cd
    private float _powerUpTimerCd;
    //Bool para a particula de movimento
    private bool _smokeMoving;
    //Quanto tempo pw de speed vai durar
    private float _activeTimer = 5f;
    /// </Variaveis>


    ///Vetores
    private Vector2 moveInput;
    private Vector3 moveVelocity;
    public Transform _smokePos;

    ///<Componentes>
    //Componente de rigidbody do player
    public Rigidbody2D playerRb;
    //Sprite para ser alterada do tank
    private SpriteRenderer sprtRendBase;
    //Controle do jogo
    public GameController _gameController;
    //Imagem para a passiva
    public Image _SpeedPwImage;
    //Animator pra animação do SpeedUp
    public Animator _speedPwAnim;
    ///</Componentes>

    
    void Start ()
    { 

        rewPlayer = ReInput.players.GetPlayer(_playerNumber);

        sprtRendBase = GetComponentInChildren<SpriteRenderer>();

        CreateTank();

        //Deixando a animação normal
        _speedPwAnim.SetBool("speedCharged", false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        VerifyEnergy(_energy);
        movePlayer();
        PowerUpSpeed();

        //Instanciando a particla quando movimenta
        if (_smokeMoving)
        {
            GameObject smokeTemp = Instantiate(_smokePtc, _smokePos.position, _smokePos.rotation);
            _smokeMoving = false;
        }




        //Debug.Log("Ativando o pw:" + _powerUpisOn);
        //Apertar X/A, para o powerUp
        if (rewPlayer.GetButton("SpeedUp"))
        {
            //Se tiver o cd pode ativar
            if (_powerUpisOn)
            {
                //Instanciando a particula
                GameObject tempSpeedPtc = Instantiate(_speedPtc, transform.position, transform.rotation);
                _activeSpeed = true;
                _powerUpisOn = false;
            }
        }



        //Input R1/RB do joystick
        if (rewPlayer.GetButton("Shoot"))
        {
            //Chamando a função de tiro
            Turret.Shoot();
        }

        //Input L1/LB do joystick
        if(rewPlayer.GetButton("PowerUp"))
        {
            //Chamando a função do pw
            Debug.Log("Atirando no input");
            Turret.RicochetPowerUp();
        }

        //Apertar (triangulo/Y) abri o menu
        if(rewPlayer.GetButton("Pause"))
        {
            _gameController.PauseGame();

        }

        if (_gameController._pausedGame)
        {
            //Apertar (quadrado/X) dentro do pause vai para a seleção de menu
            if (rewPlayer.GetButton("MenuSelection"))
            {
                _gameController.ChooseTank();
            }

            //Apertar (bolinha/B) dentro do pause vai volta para o jogo
            if (rewPlayer.GetButton("BackPause"))
            {
                _gameController.ResumeGame();
            }

            //Apertar (X/A) volta pro menu inicial do jogo
            if(rewPlayer.GetButton("Quit"))
            {
                _gameController.QuitMenu();
            }
        }

        
    }

    void movePlayer()
    {

        moveInput = new Vector2(rewPlayer.GetAxisRaw("Horizontal"), rewPlayer.GetAxisRaw("Vertical")).normalized;

        if (moveInput.magnitude > 0)
            _smokeMoving = true;
        else
            _smokeMoving = false;


        //Aplicando um novo vetor os vetores de input com minha velocidade, tempo e velocidade passiva
        moveVelocity = moveInput * _speed * _speedPU * Time.deltaTime;

        //Novo movimento com o ângulo do joystick
        playerRb.MovePosition(transform.position + moveVelocity);


        //Rotação são os dois vetores de inputs
        _rotationSpeed = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;

        //Aplicando a rotação ao valor dos vetores
        transform.rotation = Quaternion.Euler(0, 0, _rotationSpeed);

        
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


    //Função que ativa o powerup
    public void PowerUpSpeed()
    {
        //Se estiver ativo
        if (_activeSpeed)
        {
            

            //Habilita a linha
            _speedLiner.enabled = true;

            //Velocidade aumentada
            _speedPU = 3f;

            //Contador pra ver o tempo que vai durar
            _activeTimer -= Time.deltaTime;

            //Se chegar a 0 segundos, desativa
            if (_activeTimer <= 0f)
            {
                //Debug.Log("ACABOU LADRÃO!: " + _speedPU);
                _activeSpeed = false;
                _powerUpTimerCd = 0f;
               
            }
        }
        //Se não estiver ativo, o contador vai contandoo tempo do cd, até poder ativar de novo
        else
        {
            _speedLiner.enabled = false;
            _speedPU = 1f;

            //Dizendo que o fillAmount da imagem é igual o cd
            _SpeedPwImage.fillAmount = _powerUpTimerCd / 4;

            //Contando tempo do Cd
            _powerUpTimerCd += Time.deltaTime;

           
            //Se chegar a dez, deu o Cd
            if (_powerUpTimerCd >= 4)
            {
                //Ativando a pw de novo
                _powerUpisOn = true;
                //Definindo o tempo do cd pra não ficar sempre somando
                _powerUpTimerCd = 4f;
                //Zerando o tempo do pw ativo
                _activeTimer = 4f;
                //Ativar animação do pwSpeed
                _speedPwAnim.SetBool("speedCharged", true);
            }
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

        if (other.collider.CompareTag("RicoBullet"))
        {
            ApplyDamage(30, _playerNumber);
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


