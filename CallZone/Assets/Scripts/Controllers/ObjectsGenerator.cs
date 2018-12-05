using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsGenerator : MonoBehaviour {

    //Referencia do objeto a ser criado
    public GameObject _object;

    //Controle de quantidade de spawn
    public int _maxNumber;

    //Tamanho relativo para criar as instancia dentro do mapa
    public float _mapWidht, _mapHeight;



    [ContextMenu("Gerar objetos")]
    public void GenObjects()
    {
        if (transform.childCount > 0)
        {
            //Chamando a função de limpeza se já tiver um objeto na cena
            Clear();
        }

        //Instanciando os objetos pelo numero total
        for (int i = 0; i < _maxNumber; i++)
        {
            GameObject obj = Instantiate(_object, new Vector3(Random.Range(-_mapWidht, _mapWidht), Random.Range(-_mapHeight, _mapHeight)), Quaternion.identity, transform);

        }
    }

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
