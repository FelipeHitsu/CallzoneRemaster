using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicochetBullet : MonoBehaviour
{
    /// <Eventos>
    //Evento de explosão
    public delegate void ExplosionDelegate(bool active);
    public event ExplosionDelegate ExplosionEvent;
    /// </eventos>



    ///<Variáveis>
    public int _playerNumber;
    //Corpo do projétil
    public Rigidbody2D bulletRb;
    //Velocidade de movimento do projetil
    public float _speed;
    //Vida(quantidade de vezes que vai bater)
    private int _ricoLife = 5;
    //Vai ativar a explosão
    [HideInInspector]
    public bool _onExplosion = false;
    //Particula quando bate nas coisas
    public GameObject _ricoParticle;
    //Explosão que vai dar dano
    public GameObject _ricoExplosion;

    public LayerMask collisionMask;
   // private object active;

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
            //Instanciando a particula quando bate
            GameObject tempPart = Instantiate(_ricoParticle, transform.position, Quaternion.identity, transform);

            //Destruindo a particula 
            Destroy(tempPart, 1.5f);

            //Diminuindo a vida para saber quando ela vai explodir
            _ricoLife -= 1;
            Debug.Log("Vai explodir em...:" + _ricoLife);

           
           
            //Vetor de reflexão
            Vector2 reflection = Vector2.Reflect(ray.direction, hit.normal);
            //Reflect retorna o valor contrário do vetor definido como normal

            //A rotação para que o objeto siga no caminho contrário
            float rot = 90 - Mathf.Atan2(reflection.y, reflection.x) * Mathf.Rad2Deg;

            transform.eulerAngles = new Vector3(0, 0, rot);    
        }

        //Se chegar a 0, explode!
        if (_ricoLife <= 0)
        {
            Debug.Log("PQ NÃO ENTRA NO EVENTO CARALHO!?!?");
           
            //Verificando se o evento não é nulo
            if(ExplosionEvent != null)
            {
              Debug.Log("VAI CARALHO!@@@@@@@@@@@@: " + ExplosionEvent != null);
              //A call do evento passando que a explosão está pronta
              ExplosionEvent.Invoke(_onExplosion = true);
              Destroy(gameObject);
              _ricoLife = 5;
            }

            //_onExplosion = true;
            //_ricoLife = 5;
        }

        //if(_onExplosion)
        //{
        //    //Instanciando a particula
        //    GameObject tempExplo = Instantiate(_ricoExplosion, transform.position, Quaternion.identity, transform);

        //    //Destruindo o objeto
        //    Destroy(gameObject);
        //    _onExplosion = false;

        //}
    }


    public void SetBullet(int player)
    {
        _playerNumber = player;
    }

    
}
