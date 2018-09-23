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



    // Update is called once per frame
    void Update()
    {
        GetInformation();
        SetPlayerStatus();
    }

    public void SetPlayerStatus()
    {
        _speed = TankSettings.tankInfo[PlayerNumber].baseTank._speed;
        _life = TankSettings.tankInfo[PlayerNumber].baseTank._life;
        _fireRate = TankSettings.tankInfo[PlayerNumber].turret._fireRate;
        _damage = TankSettings.tankInfo[PlayerNumber].turret._damage;


    }

    public void GetInformation()
    {
        _LifeTxt.text = TankSettings.tankInfo[PlayerNumber].baseTank._BodySprite.name +" " + "life: " +  _life;
        _speedTxt.text = TankSettings.tankInfo[PlayerNumber].baseTank._BodySprite.name + " " + "speed: " + _speed;
        _fireRateTxt.text = TankSettings.tankInfo[PlayerNumber].turret._TowerSprite.name + " " + "fire rate: " + _fireRate;
        _DamageTxt.text = TankSettings.tankInfo[PlayerNumber].turret._TowerSprite.name + " " + "damage: " + _damage;
    }

}