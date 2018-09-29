using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class rotateTurret : MonoBehaviour {

    [SerializeField]
    private GameObject shoot;

    public Transform shootspawn;

    
    private SpriteRenderer sprtRendTurret;

    //Pra saber qual jogador que é
    public int _playerNumber;

    public float _fireRate;
    private float _rotationSpeed;
    public float _damage;

    private float _fireReloadTimer = 0.0f;

    private bool _fireUp = false;

    private Vector3 turretRotation;

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
        ///Futuramente: Deixar a rotação com o Joystick, no analógico direito

        if (rewPlayer.GetButton("TurnTurretRight"))
        {
            Debug.Log("VIRA DIREITAAAAAAAAAA, CARALHOOOOOO");
            turretRotation.z += _rotationSpeed;
        }
        if(rewPlayer.GetButton("TurnTurretLeft"))
        {
            Debug.Log("VIRA ESQUERDAAAAAAAA, CARALHOOOOOO");
            turretRotation.z -= _rotationSpeed;
        }

        transform.rotation = Quaternion.Euler(turretRotation);

        ////Rotação
        //Vector3 mousePos = Input.mousePosition;

        //mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        //transform.right = direction;
    }

    
    public void Shoot()
    {
       ///Furutamente: Deixar esse input para o Joystick, ou seja aqui seria o quadrado para atirar.
         if (_fireUp)
         {
                
                //Criando instancia temporária para o tiro
                GameObject tempBullet = Instantiate(shoot, shootspawn.position, Quaternion.identity);
                tempBullet.transform.right = transform.right;

                _fireReloadTimer = 0;
                _fireUp = false;

                //Destruindo objeto depois de 4 segundos
                Destroy(tempBullet, 4.0f);
            }
        
    }

    public void DefineTurret(TankTurret turret)
    {
        
        //O tank é carregado, mas a sprite não!

        //Sprite do canhão
        sprtRendTurret.sprite = turret._TowerSprite;
       

        ////O projétil do canhão
        shoot = turret._bullet;

        //Velocidade de tiro
        _fireRate = TankSettings.tankInfo[_playerNumber].turret._fireRate;
        //Velocidade de rotação
        _rotationSpeed = TankSettings.tankInfo[_playerNumber].turret._turnSpeed;
        //Dano do canhão
        _damage = TankSettings.tankInfo[_playerNumber].turret._damage;

    }
   
}
