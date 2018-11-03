using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    ///<Particulas>
    //Particla de sangue do jogador
    public GameObject _ketchupParticle;
    //Particle explosion na pedra
    public GameObject particleExplosion;
    //Quando acerta uma comida
    public GameObject _foodExplosion;
    //Quando acerta a parede
    public GameObject _wallExplosion;
    /// </Particulas>


    //Velocidade de movimento do projetil
    public float speed;

    public Rigidbody2D bulletRb;

    int _playerNumber;


    // Use this for initialization
    void Start()
    {
        
        //Pegando o componente do projétil
        bulletRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Deixei com transform pq funciona sem aquele bug bizarro do Move.Positions
        bulletRb.MovePosition(transform.position + transform.right * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Verificando se houve colisão com a pedra
        if (other.gameObject.CompareTag("pedroso"))
        {
            //Efeito de explosão quando bate na pedra
            GameObject tempExp = Instantiate(particleExplosion, transform.position, Quaternion.identity);
            Destroy(tempExp, 1.0f);

            //Destruindo o objeto, no caso o projétil
            Destroy(gameObject);
        }

        //Verificando se houve colisão com o jogador adversário e chamando a função que aplica o dano
        if (other.gameObject.CompareTag("Player"))
        {
            //Particlua de colisão com o jogadore
            GameObject tempKetc = Instantiate(_ketchupParticle, transform.position, Quaternion.identity);
            Destroy(tempKetc, 1.0f);

            //Pegando o componente do tank para chamar a função de dano com o valor
            other.collider.GetComponent<PlayerTank>().ApplyDamage((int)other.collider.GetComponent<PlayerTank>().Turret._damage, _playerNumber);

            //Destruindo o projétil
            Destroy(gameObject);
        }

        if(other.gameObject.CompareTag("Food"))
        {
            //Instancia uma cópa da particula
            GameObject tempFood = Instantiate(_foodExplosion, transform.position, Quaternion.identity);
            //Destroi a cópia
            Destroy(tempFood, 1.2f);

            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Box"))
        {
            //Instancia uma cópa da particula
            GameObject tempFood = Instantiate(_foodExplosion, transform.position, Quaternion.identity);
            //Destroi a cópia
            Destroy(tempFood, 1.2f);

            //Destroi a caixa
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Wall"))
        {
            //Instancia uma cópa da particula
            GameObject tempWallExplosion = Instantiate(_wallExplosion, transform.position, Quaternion.identity);
            //Destroi a cópia
            Destroy(tempWallExplosion, 1.0f);

            //Destrói o projétil
            Destroy(gameObject);
        }
        
    }

    public  void SetBullet(int player)
    {
        _playerNumber = player;
    }

    



}
