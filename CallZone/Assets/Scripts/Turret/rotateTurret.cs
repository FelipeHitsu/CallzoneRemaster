using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class rotateTurret : MonoBehaviour {

    /// <Particulas>
    //Particulas de quando atira
    public GameObject _shootingParticle;
    /// </Particulas>


    ///<Componentes>
    //Objeto de tiro
    private GameObject shoot;
    //Objeto de pw
    private GameObject _powerUpShoot;
    //Posição do tiro-
    public Transform shootspawn;
    //Gerenciador de som
    public AudioController soundController;
    //Pra saber qual sprite será desenhado
    private SpriteRenderer sprtRendTurret;
    ///</Componentes>
    
    ///<Variaveis>
    //Pra saber qual jogador que é
    public int _playerNumber;
    //Intervalo de tiros
    public float _fireRate;
    //Velocidade da rotação da torre
    private float _rotationSpeed;
    //Quanto de dano cada torre da
    public float _damage;
    //Dano do pw
    private float _damagePw;
    //Reloader do tiro
    private float _fireReloadTimer = 0.0f;
    //Pra saber se pode atirar de novo
    private bool _fireUp = false;
    //Som de tiro do canhão
    public AudioClip _effectSound;
    ///</Variaveis>

    private Vector2 moveInput;

    /// <Rewired>
    private Player rewPlayer;
    /// </Rewired>

    void Awake()
    {
        sprtRendTurret = GetComponent<SpriteRenderer>();
        rewPlayer = ReInput.players.GetPlayer(_playerNumber);
    }

	void Update ()
    {
        //Timer de reload
        if(!_fireUp)
        {
            //Contandoo tempo para o reload
            _fireReloadTimer += Time.deltaTime;

            //Verificando o tempo, se for maior que o tempo de reload, atira
            if(_fireReloadTimer >= _fireRate)
             { _fireUp = true; }   
        }
        
        rotate();	
	}

    void rotate()
    {
        moveInput = new Vector2(rewPlayer.GetAxisRaw("Right_Horizontal"), rewPlayer.GetAxisRaw("Right_Vertical")).normalized;

        //Rotação são os dois vetores de inputs
        _rotationSpeed = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, _rotationSpeed);
    }

    
    public void Shoot()
    {
       
         if (_fireUp)
         {
            //Particula de tiro
            GameObject tempShoot = Instantiate(_shootingParticle, shootspawn.position, Quaternion.identity);
            


            ///Sons de tiro
            //Torre de tubos
            if (TankSettings.tankInfo[_playerNumber].turret.name == "DoubleTubes")
                soundController.Playsound(1, 0, false);
            //Tore de sorvete
            if (TankSettings.tankInfo[_playerNumber].turret.name == "IceCream")
                soundController.Playsound(1, 1, false);
            //Torre de salsicha
            if (TankSettings.tankInfo[_playerNumber].turret.name == "Sausage")
                soundController.Playsound(1, 2, false);
            //Torre de cenoura
            if (TankSettings.tankInfo[_playerNumber].turret.name == "Carrot")
                soundController.Playsound(1, 3, false);


            //Criando instancia temporária para o tiro
            GameObject tempBullet = Instantiate(shoot, shootspawn.position, Quaternion.identity);
            tempBullet.transform.right = transform.right;

            tempBullet.GetComponent<BulletMovement>().SetBullet(_playerNumber);

           _fireReloadTimer = 0;
           _fireUp = false;

         }
    }

    public void RicochetPowerUp()
    {
        //Instanciar o pw
        Debug.Log("Ricochet lives!?!?!");
        GameObject tempPw = Instantiate(_powerUpShoot, shootspawn.position, Quaternion.identity);
        tempPw.transform.right = transform.right;

        tempPw.GetComponent<RicochetBullet>().SetBullet(_playerNumber);

    }


    public void DefineTurret(TankTurret turret)
    {
        //Sprite do canhão
        sprtRendTurret.sprite = turret._TowerSprite;
       
        //O projétil do canhão
        shoot = turret._bullet;

        //Velocidade de tiro
        _fireRate = TankSettings.tankInfo[_playerNumber].turret._fireRate;

        //Velocidade de rotação
        _rotationSpeed = TankSettings.tankInfo[_playerNumber].turret._turnSpeed;

        //Dano do canhão
        _damage = TankSettings.tankInfo[_playerNumber].turret._damage;

        //Dano do pw
        _damagePw = TankSettings.tankInfo[_playerNumber].powerUp._damage;

        //Projétil de pw
        _powerUpShoot = TankSettings.tankInfo[_playerNumber].powerUp._powerUp;
    }
   
}
