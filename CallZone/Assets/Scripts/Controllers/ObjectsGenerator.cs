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

    // Use this for initialization
    void Start ()
    { 
        //Instanciando os objetos pelo numero total
        for (int i = 0; i < _maxNumber; i++)
        {
            GameObject obj = Instantiate(_object, new Vector3(Random.Range(-_mapWidht, _mapWidht), Random.Range(-_mapHeight, _mapHeight)), Quaternion.identity, transform);

        }

    }
	
	
}
