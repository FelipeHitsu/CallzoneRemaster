using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateTurret : MonoBehaviour {

    [SerializeField]
    private GameObject shoot;

    public Transform shootspawn;

    public SpriteRenderer spritRendTurret;

    public int _playerNumber;

    private float _fireRate;
    private float _rotationSpeed;
    private float _damage;

    private float _fireReloadTimer;

    private bool _fireUp;

	// Update is called once per frame
	void Update ()
    {
        if(!_fireUp)
        {
            _fireReloadTimer += Time.deltaTime;
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

            Destroy(tempBullet, 4.0f);
        }
        
    }

    public void DefineTurret(TankTurret turret)
    {
        spritRendTurret.sprite = turret._TowerSprite;
        shoot = turret._bullet;

        //Velocidade de tiro
        _fireRate = TankSettings.tankInfo[_playerNumber].turret._fireRate;
        //Velocidade de rotação
        _rotationSpeed = TankSettings.tankInfo[_playerNumber].turret._turnSpeed;

    }

   
}
