using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {

    //Os toggles de coletáveis
    public Toggle[] collectable;

    public int playerNumerHUD;

	// Use this for initialization
	void Start ()
    {
         

        //Desabilitando todos os toggles
		for(int i = 0; i < collectable.Length; i++)
        {
            collectable[i].isOn = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Função que verifica se um tipo especifico de comida foi coletado e diz que a HUD está positiva
    public void Collected(FoodType type)
    {
        collectable[(int)type].isOn = true;
    }
}
