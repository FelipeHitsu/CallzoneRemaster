using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTank : MonoBehaviour
{

   
    //public GameObject[] tanks;



    //public float spawnX, spawnY;


    //// Use this for initialization
    //void Start()
    //{


    //    MakeTank();

    //    BringTank();
    //}


    //void InstantiateTank(TankInfo tank)
    //{
    //    GameObject tankController = Instantiate(tanks[tank._numberTankRew], new Vector2(Random.Range(-spawnX, spawnX), Random.Range(-spawnY, spawnY)), Quaternion.identity);
    //   // tankController.GetComponent<PlayerTank>()._playerNumber = tank.playerNumber;
       


    //}

    //public void BringTank()
    //{
    //    var tanks = FindObjectsOfType<TankInfo>();
    //    Debug.Log(tanks);

    //    //Instancia dos tanks vindo do menu
    //    for (int i = 0; i < tanks.Length; i++)
    //    {
    //        InstantiateTank(tanks[i]);


    //        if (tanks[i].gameObject != gameObject)
    //            Destroy(tanks[i].gameObject);
    //        else
    //        {
    //            Destroy(tanks[i]);
    //        }
    //    }
    //}


    //public void MakeTank()
    //{
    //    var tanks = FindObjectsOfType<TankInfo>();

    //    //Cirar os tanks sem o menu, para testes e tudo mais
    //    if (tanks.Length < 2)
    //    {
    //        tanks = new TankInfo[2];

    //        for (int i = 0; i < tanks.Length; i++)
    //        {
    //            tanks[i] = gameObject.AddComponent<TankInfo>();
    //           // tanks[i].playerNumber = i;
    //            tanks[i]._numberTankRew = i;
    //        }
    //    }

    //}
}
