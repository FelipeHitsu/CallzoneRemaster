using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{

    public PlayerTank tank;

    //Barra de vida do jogador
    [SerializeField]
    private Image barLife;

    [SerializeField]
    //Barra de energia do jogador
    private Image barEnergy;

	// Use this for initialization
	void Start ()
    {
        //Agora minha hud escuta esse evento
        tank.DamageEvent += OnDamage;

        tank.EnergyEvent += OnEnergy;

        barEnergy.fillAmount = 0;
	}
	
    //Desub do evento
    void OnDisable()
    {
        tank.DamageEvent -= OnDamage;
        tank.EnergyEvent -= OnEnergy;
    }

    //Função do dano
    public void OnDamage (float life)
    {

        barLife.fillAmount = life;
    }

    //função da energia
    public void OnEnergy (float energy)
    {
        barEnergy.fillAmount = energy;
        Debug.Log("Minha energia: " + barEnergy.fillAmount);
    }
}
