using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUDMenu : MonoBehaviour
{

    //Variáveis de texto para UI dos tanks no menu
    public Text _LifeTxt;
    public Text _speedTxt;
    public Text _fireRateTxt;
    public Text _DamageTxt;


    //Variáveis que conterão as informações do jogador
    private float _speed;
    private int _life;
    private float _fireRate;
    private int _damage;

    public int PlayerNumber;

    //private TankSettings baseTank;
    //private TankSettings turretTank;


    // Update is called once per frame
    void Update()
    {
        GetInformation();
        SetPlayerStatus();
    }

    public void SetPlayerStatus()
    {
        _speed = TankSettings.tankInfo[PlayerNumber]._speed;
        _life = TankSettings.tankInfo[PlayerNumber]._life;
        _fireRate = TankSettings.tankInfo[PlayerNumber]._fireRate;
        _damage = TankSettings.tankInfo[PlayerNumber]._damage;


    }

    public void GetInformation()
    {
        _LifeTxt.text = _life.ToString("Tank Life: " + _life);
        _speedTxt.text = _speed.ToString("Tank Speed: " + _speed);
        _fireRateTxt.text = _fireRate.ToString("Your Fire rate: " + _fireRate);
        _DamageTxt.text = _damage.ToString("Your damage: " + _damage);
    }

}