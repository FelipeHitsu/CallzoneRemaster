using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour {
    
    //Referencia ao objeto de comida para ser criado
    public GameObject food;

    //Numero maximo de comidas que serão criados para a cena
    public int numberFood;

    //Tamanho relativo para criar as instancia dentro do mapa
    public float mapWidht, mapHeight;


    //Função para criar os objetos na cena, com o tamanho aproximado do mapa
    [ContextMenu("Gerar fase")]
    public void GenLevel()
    {
        if(transform.childCount > 0)
        {
            //Chamando a função de limpeza se já tiver um objeto na cena
            Clear();
        }

        //Instanciando os objetos pelo numero total
        for (int i = 0; i < numberFood; i++)
        {
            int rand = Random.Range(0, 6);

            GameObject obj = Instantiate(food, new Vector3(Random.Range(-mapWidht, mapWidht), Random.Range(-mapHeight, mapHeight)), Quaternion.identity, transform);

            //Dizendo que o objeto instanciado é do tipo comida
            obj.GetComponent<Collectable>().SetFood(rand);

        }
    }

    //Função para limpar os objetos criados da cena, todos eles
    [ContextMenu("Limpador")]
    private void Clear()
    {
        //Pegando todos os componentes filhos da cena
        var childFood = GetComponentsInChildren<Transform>();

        //Varrendo todos os filhos da cena e verificando se é diferente deste objeto
        for (int i = 0; i < childFood.Length; i++)
        {
            if (childFood[i].gameObject != gameObject)
            {
                //Destruindo todos os objetos gerados dentro da cena
                DestroyImmediate(childFood[i].gameObject);     
            }
        }
    }

}
