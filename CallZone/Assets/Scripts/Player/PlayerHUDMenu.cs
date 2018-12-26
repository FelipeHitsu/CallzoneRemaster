using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUDMenu : MonoBehaviour
{

    //Variáveis de texto para UI dos tanks no menu
    public TextMeshProUGUI _lifeTMP;
    public TextMeshProUGUI _speedTMP;
    public TextMeshProUGUI _fireRateTMP;
    public TextMeshProUGUI _damageTMP;

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
        
        _lifeTMP.text = TankSettings.tankInfo[PlayerNumber].baseTank._BodySprite.name + " " + "Life .... " + _life;
        _speedTMP.text = TankSettings.tankInfo[PlayerNumber].baseTank._BodySprite.name + " " + "Speed .... " + _speed;
        _fireRateTMP.text = TankSettings.tankInfo[PlayerNumber].turret._TowerSprite.name + " " + "Fire rate .... " + _fireRate;
        _damageTMP.text = TankSettings.tankInfo[PlayerNumber].turret._TowerSprite.name + " " + "Damage .... " + _damage;
    }

}