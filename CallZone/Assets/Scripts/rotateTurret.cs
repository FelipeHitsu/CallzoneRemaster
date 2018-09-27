using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateTurret : MonoBehaviour {

    [SerializeField]
    private GameObject shoot;

    public Transform shootspawn;

    private SpriteRenderer sprtRendTurret;

    public int _playerNumber;

    public float _fireRate;
    private float _rotationSpeed;
    public float _damage;

    private float _fireReloadTimer;

    private bool _fireUp = false;

	// Update is called once per frame
	void Update ()
    {
        DefineTurret(TankSettings.tankInfo[_playerNumber].turret);

        //Timer de reload
        if(!_fireUp)
        {
            //Contandoo tempo para o reload
            _fireReloadTimer += Time.deltaTime;

            //Verificando o tempo, se for maior que o tempo de reload, atira
            if(_fireReloadTimer >= _fireRate)
            {
                _fireUp = true;
                _fireReloadTimer = 0;
            }   
        }
        

        rotate();	
	}

    void rotate()
    {
        ///Futuramente: Deixar a rotação com o Joystick, no analógico direito

        //Rotação
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.right = direction;
    }

    
    public void Shoot()
    {

        ///Furutamente: Deixar esse input para o Joystick, ou seja aqui seria o R1 para atirar.
        if (_fireUp)
        {
            //Se apertar click do mouse e o tempo for menor que o tempo de reload de cada canhão, atira
            GameObject tempBullet = Instantiate(shoot, shootspawn.position, Quaternion.identity);
            tempBullet.transform.right = transform.right;

            //Destruindo objeto depois de 4 segundos
            Destroy(tempBullet, 4.0f);
        }
        
    }

    public void DefineTurret(TankTurret turret)
    {
        //Sprite do canhão
        sprtRendTurret.sprite = turret._TowerSprite;
         Debug.Log("Não carregado" + sprtRendTurret.sprite == null);

        //O projétil do canhão
        shoot = turret._bullet;

        //Velocidade de tiro
        _fireRate = TankSettings.tankInfo[_playerNumber].turret._fireRate;
        //Velocidade de rotação
        _rotationSpeed = TankSettings.tankInfo[_playerNumber].turret._turnSpeed;
        //Dano do canhão
        _damage = TankSettings.tankInfo[_playerNumber].turret._damage;

    }

   
}
