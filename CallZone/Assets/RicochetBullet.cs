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
	
	
	void Update ()
    {
        //Movimentação do projétil
        bulletRb.MovePosition(transform.position + transform.right * _speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Verificando se houve colisão com os objetos do cenário
        if (other.gameObject.CompareTag("pedroso") || other.gameObject.CompareTag("Player") ||
            other.gameObject.CompareTag("Box") || other.gameObject.CompareTag("Wall"))
        {
            //Vector3 reflect = Vector3.Reflect(transform.forward, other.contacts[0].normal);
            //float rot = 90 - Mathf.Atan2(reflect.z, reflect.x) * Mathf.Rad2Deg;
            //transform.eulerAngles = new Vector3(90, rot, 0);

            //Traço de raycast com as minhas posições
            Ray ray = new Ray(transform.position, transform.up);
            //Alvo do meu raycast
            RaycastHit hit;
            //Verificando a colisão do raycast
            if (Physics.Raycast(ray, out hit, Time.deltaTime * _speed + 0.1f, collisionMask))
            {
                //Vetor de reflexão
                Vector2 reflection = Vector2.Reflect(ray.direction, hit.normal);
                //Reflect retorna o valor contrário do vetor definido como normal
                //A rotação para que o objeto siga no caminho contrário
                float rott = 90 - Mathf.Atan2(reflection.y, reflection.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, 0, rott);

            }

            //_ricoLife -= 1;
            //Debug.Log("vida bala ricochete:" + _ricoLife);
            //if (_ricoLife <= 0) _onExplosion = true;

        }
    }

    public void SetBullet(int player)
    {
        _playerNumber = player;
    }
}
