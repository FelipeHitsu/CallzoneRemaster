using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{

    public PlayerTank tank;

    //Barra de vida do jogador
    public PlayerStatus barLife;

    //Barra de energia do jogador
    public PlayerStatus barEnergy;

	// Use this for initialization
	void Start ()
    {
        //Agora minha hud escuta esse evento
        tank.DamageEvent += OnDamage;

        tank.EnergyEvent += OnEnergy;
       
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
        
        barLife.SetFillAmountLife(life);
    }

    //função da energia
    public void OnEnergy (float energy)
    {
        barEnergy.SetFillAmountEnergy(energy);
    }
}
