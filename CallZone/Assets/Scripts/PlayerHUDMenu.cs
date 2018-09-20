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

    private PlayerTank playerTank;

    // Use this for initialization
    void Start()
    {
        var tank = FindObjectsOfType<PlayerTank>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void InformationMenu()
    //{


    //}

}

