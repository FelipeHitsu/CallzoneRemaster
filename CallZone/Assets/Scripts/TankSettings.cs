using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TankSettings
{
    public static TankInformation[] tankInfo = new TankInformation[2];

    ////Variáveis que conterão as informações do tank
    //public  float _speed;
    //public int _life;

    ////Variáveis que conterão as informações da torre
    //public float _fireRate;
    //public int _damage;

}

public class TankInformation
{
    public float _speed;
    public GameObject _bullet;
    public Sprite _BodySprite;
    public Sprite _TowerSprite;
    public float _turnSpeed;
    public int _life;
    public float _fireRate;
    public int _damage;
}
