using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicochetBullet : MonoBehaviour
{
    public int _playerNumber;
    //Corpo do projétil
    public Rigidbody2D bulletRb;
    //Velocidade de movimento do projetil
    public float _speed;
    //Vida(quantidade de vezes que vai bater)
    private int _ricoLife = 3;
    //Vai ativar a explosão
    private bool _onExplosion = false;

    public LayerMask collisionMask;

    void Start ()
    {
        //Pegando o componente do projétil
        bulletRb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //Movimentação do projétil
        bulletRb.MovePosition(transform.position + transform.right * _speed * Time.deltaTime);


        //Traço de raycast com as minhas posições
        Ray2D ray = new Ray2D(transform.position, transform.right);

        //Alvo do meu raycast
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Time.deltaTime * _speed + 0.1f, collisionMask);

        //Verificando a colisão do raycast
        if (hit.collider != null)
        {
            Debug.Log("Acertou");
           
            //Vetor de reflexão
            Vector2 reflection = Vector2.Reflect(ray.direction, hit.normal);
            //Reflect retorna o valor contrário do vetor definido como normal

            //A rotação para que o objeto siga no caminho contrário
            float rott = 90 - Mathf.Atan2(reflection.y, reflection.x) * Mathf.Rad2Deg;
            
            transform.eulerAngles = new Vector3(0, 0, rott);

           //Quase lá......como sempre
        }





    }


    public void SetBullet(int player)
    {
        _playerNumber = player;
    }
}
