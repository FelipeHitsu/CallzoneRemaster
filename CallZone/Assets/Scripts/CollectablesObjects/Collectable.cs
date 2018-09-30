using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FoodType
{
    //Colocando a ordem dentro do enum de cada tipo de comida
    Cenoura, Cogumelo, Milho, Ovo, Pao, Queijo

};

public class Collectable : MonoBehaviour {

    
    
    //Todas as sprites das comidas
    public Sprite[] sprites;
    //Enum dos tipos de comida
    public FoodType foodType;

    public float foodEnergy = 50;

    private SpriteRenderer spriteRend;

	// Use this for initialization
	void Start () {

        //Pegando o componente de sprite
        spriteRend = GetComponent<SpriteRenderer>();
    }

    //Função que define para ser a comida
    public void SetFood(int food)
    {
        //Peganmdo o componente de sprite e dizendo que ele na posição food, é uma comida
        spriteRend.sprite = sprites[food];

        //Dizendo que a comida é igual ao index criado para ser ele
        foodType = (FoodType)food;
    }
   
}
