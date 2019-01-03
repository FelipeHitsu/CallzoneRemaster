using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankInfo
{

   public TankBase baseTank;
   public TankTurret turret;
   public PowerUp powerUp;
    
}

[System.Serializable]
public class TankBase
{
    public string name;
    public float _speed;
    public int _life;
    public Sprite _BodySprite;
    
}

[System.Serializable]
public class TankTurret
{
    public string name;
    public GameObject _bullet;
    public Sprite _TowerSprite;
    public float _turnSpeed;
    public float _fireRate;
    public int _damage;
   
}

[System.Serializable]
public class PowerUp
{
    public string name;
    public GameObject _powerUp;
    public Sprite _pwSprite;
    public int _damage;
}
    

