using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankInfo : MonoBehaviour {

    //Array de sprites para alterar os modelos dos tanks
    public Sprite[] spritesTanksBase;
    
    //Texto para exibir o nome do modelo
    public Text tankName;

    //Inidice usado no array dos modelos
    private int indexInitial = 0;
    
    //Componente de spriteRendenrer para cada objeto
    private SpriteRenderer spriteRend;

    //Numero do tank
    public int numberTank;

    public int playerNumber;

    public Button advance;
    public Button back; 

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(gameObject);

        //Pegando o componente para sprite
        spriteRend = GetComponentInChildren<SpriteRenderer>();
        //Chamada da função que define o index como 0
        SetInitial(indexInitial);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Verificando o index do modelo atual e desativando o botão quando chegar no último modelo, seja indo ou voltando
        if (indexInitial >= spritesTanksBase.Length - 1) { advance.interactable = false; }
        else { back.interactable = true; }

        if (indexInitial <= 0) {back.interactable = false; }
        else {advance.interactable = true;}


    }

    //Aplica a primeira sprite como padrão de modelo do tank
    public void SetInitial(int index)
    {
        spriteRend.sprite = spritesTanksBase[index];
        string tankname = spritesTanksBase[index].name;

        tankName.text = tankname;
        
    }

    //Função que avança o modelo do tanque quando o botão for pressionado
    public void AdvanceButton()
    {
        //Avançando dentro do indice de arrays de cada modelo
        spriteRend.sprite = spritesTanksBase[indexInitial += 1];
        string tankname = spritesTanksBase[indexInitial].name;

        tankName.text = tankname;

        //Este é o numero do tank que será criado no jogo
        numberTank = indexInitial;
       
    }

    //Função que volta do modelo do tanquye quando o botão for pressionado
    public void BackButton()
    {
        //Voltando dentro do incide de arrays de cada modelo
        spriteRend.sprite = spritesTanksBase[indexInitial -= 1];
        string tankname = spritesTanksBase[indexInitial].name;

        tankName.text = tankname;

        numberTank = indexInitial;
        
    }

    
  
}
