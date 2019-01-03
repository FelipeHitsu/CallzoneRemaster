using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicochetBullet : MonoBehaviour
{
    /// <Eventos>
    //Evento de explosão
    public delegate void ExplosionDelegate();
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
    public GameObject _ricoExplo;
    //Animator para animação
    private Animator _ricoAnim;
    
    public LayerMask collisionMask;
   

    void Start ()
    {
        //Pegando o componente do projétil
        bulletRb = GetComponent<Rigidbody2D>();

        //Pegando animator
        _ricoAnim = GetComponent<Animator>();
    }


    void Update()
    {
        //Dizendo que a vida da bala é igual do animator, pra poder ativar as animações
        _ricoAnim.SetInteger("_ricoLife", _ricoLife);

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
            
            _onExplosion = true;
            ricoExplosion(_onExplosion);
        }

            
    }


    public void ricoExplosion(bool active)
    {
        if(active)
        {
            //Instanciando a particula
            GameObject tempExplo = Instantiate(_ricoExplo, transform.position, transform.rotation);
            //Destroi o objeto
            Destroy(gameObject);
            //Reseta a vida da bala pro proximo uso
            _ricoLife = 5;
            //Dizendo que a explosão já foi
            _onExplosion = false;
        }
    }

    public void SetBullet(int player)
    {
        _playerNumber = player;
    }

}

