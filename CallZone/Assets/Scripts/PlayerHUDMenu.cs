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
        _LifeTxt.text = "Tank Life: " + _life;
        _speedTxt.text = "Tank Speed: " + _speed;
        _fireRateTxt.text = "Your Fire rate: " + _fireRate;
        _DamageTxt.text = ("Your damage: " + _damage);

        Debug.Log("valor vida: " + _life);
    }

}