﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankInfo : MonoBehaviour {

    //Array de sprites para alterar os modelos dos tanks
    public Sprite[] _spritesTank;

    //Texto para exibir o nome do modelo
    public Text _tankName;

    //Inidice usado no array dos modelos
    private int _indexinitialBase = 0;

    //Componente de spriteRendenrer para cada objeto
    private SpriteRenderer _spriteRend;

    //Numero do tank
    public int _numberTank;

    //Botões para a escolha das base e torres
    public Button advanceBase;
    public Button backBase;

    // Use this for initialization
    void Start()
    {

        //Pegando o componente para sprite
        _spriteRend = GetComponentInChildren<SpriteRenderer>();

        //Chamada da função que define o index como 0
        SetInitial(_indexinitialBase);

    }

    // Update is called once per frame
    void Update()
    {
        VerifyIndex(_indexinitialBase);
   

    }

    //Aplica a primeira sprite como padrão de modelo do tank
    public void SetInitial(int index)
    {
        //Base
        _spriteRend.sprite = _spritesTank[index];
        string tankname = _spritesTank[index].name;

        _tankName.text = tankname;


    }

    //Função que avança o modelo do tanque quando o botão for pressionado
    public void AdvanceModelButton()
    {
        //Avançando dentro do indice de arrays de cada modelo de base
        _spriteRend.sprite = _spritesTank[_indexinitialBase += 1];
        string tankname = _spritesTank[_indexinitialBase].name;

        _tankName.text = tankname;
    
    }

    //Função que volta do modelo do tanque quando o botão for pressionado
    public void BackModelButton()
    {
        //Voltando dentro do incide de arrays de cada modelo
        _spriteRend.sprite = _spritesTank[_indexinitialBase -= 1];
        string tankname = _spritesTank[_indexinitialBase].name;

        _tankName.text = tankname;

    }

    public void VerifyIndex(int index)
    {
        ///Base
        //Verificando o index do modelo atual e desativando o botão quando chegar no último modelo, seja indo ou voltando
        if (index >= _spritesTank.Length - 1) { advanceBase.interactable = false; }
        else { backBase.interactable = true; }

        if (index <= 0) { backBase.interactable = false; }
        else { advanceBase.interactable = true; }
  
    }
    
}
