using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FoodType
{
    //Colocando a ordem dentro do enum de cada tipo de comida
    Bife, Frango, Melancia, ovo, queijo, sushi

};



public class Collectable : MonoBehaviour {

   

    //Todas as sprites das comidas
    public Sprite[] sprites;
    //Enum dos tipos de comida
    public FoodType foodType;

    public float foodEnergy = 50;

	
    //Função que define para ser a comida
    public void SetFood(int food)
    {
        //Peganmdo o componente de sprite e dizendo que ele na posição food, é uma comida
        GetComponent<SpriteRenderer>().sprite = sprites[food];

       
        //Dizendo que a comida é igual ao index criado para ser ele
        foodType = (FoodType)food;
    }
   
}
