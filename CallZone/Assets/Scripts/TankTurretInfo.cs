using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankTurretInfo : MonoBehaviour
{

    //Array de sprites para alterar os modelos dos tanks
    public Sprite[] _spritesTurret;
   

    //Texto para exibir o nome do modelo
    public Text _turretName;

    //Inidice usado no array dos modelos
    private int _indexInitial = 0;

    //Componente de spriteRendenrer para cada objeto
    private SpriteRenderer _spriteRend;

    //Numero do tank
    public int numberTankRew;

    //Botões para as escolhas de torres
    public Button _advance;
    public Button _back;

    //Numero da torre para ser criado no gameplay
    public int _turretNumber;

    ////Informações da torre
    //public float _fireRate;
    //public int _damage;

    // Use this for initialization
    void Start()
    {

        //Pegando o componente para sprite
        _spriteRend = GetComponent<SpriteRenderer>();

        //Chamada da função que define o index como 0
        SetInitial(_indexInitial);
    }

    // Update is called once per frame
    void Update()
    {
        //Verificando o index do modelo atual e desativando o botão quando chegar no último modelo, seja indo ou voltando
        if (_indexInitial >= _spritesTurret.Length - 1) { _advance.interactable = false; }
        else { _back.interactable = true; }

        if (_indexInitial <= 0) { _back.interactable = false; }
        else { _advance.interactable = true; }

        _turretNumber = _indexInitial;
    }

    //Aplica a primeira sprite como padrão de modelo do tank
    public void SetInitial(int index)
    {
        _spriteRend.sprite = _spritesTurret[index];
        string tankname = _spritesTurret[index].name;

        _turretName.text = tankname;

    }

    //Função que avança o modelo do tanque quando o botão for pressionado
    public void AdvanceButton()
    {
        //Avançando dentro do indice de arrays de cada modelo
        _spriteRend.sprite = _spritesTurret[_indexInitial += 1];
        string tankname = _spritesTurret[_indexInitial].name;

        _turretName.text = tankname;
    }

    //Função que volta do modelo do tanque quando o botão for pressionado
    public void BackButton()
    {
        //Voltando dentro do incide de arrays de cada modelo
        _spriteRend.sprite = _spritesTurret[_indexInitial -= 1];
        string tankname = _spritesTurret[_indexInitial].name;

        _turretName.text = tankname;
    }

}
