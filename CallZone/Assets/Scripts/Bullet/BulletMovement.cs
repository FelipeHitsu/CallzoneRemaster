﻿using System.Collections;
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


    ///<Componentes>
    private CamShake _camShake;
    //Corpo do projétil
    public Rigidbody2D bulletRb;
    ///</Componentes>
   

   

    /// <Variaveis>
    //Numero do jogador
    int _playerNumber;
    //Velocidade de movimento do projetil
    public float speed;
    /// </Variveis>


    // Use this for initialization
    void Start()
    {
        //Pegando a referencia para a camera no inicio do jogo
        _camShake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CamShake>();

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

        //Verificando se houve colisão com o jogador adversário
        if (other.gameObject.CompareTag("Player"))
        {
            //Ativando o screenshake quando atinge outro jogador
            _camShake.screenShake();

            //Particlua de colisão com o jogadore
            GameObject tempKetc = Instantiate(_ketchupParticle, transform.position, Quaternion.identity);
            Destroy(tempKetc, 1.0f);

            //Pegando o componente do tank para chamar a função de dano com o valor
            other.collider.GetComponent<PlayerTank>().ApplyDamage((int)other.collider.GetComponent<PlayerTank>().Turret._damage, _playerNumber);

            //Destruindo o projétil
            Destroy(gameObject);
        }

        //Verificando colisão com a comida
        if(other.gameObject.CompareTag("Food"))
        {
            //Instancia uma cópa da particula
            GameObject tempFood = Instantiate(_foodExplosion, transform.position, Quaternion.identity);

            //Destroi a cópia
            Destroy(tempFood, 1.2f);

            Destroy(other.gameObject);
        }

        //Verificando colisão com as caixas do cenário
        if (other.gameObject.CompareTag("Box"))
        {
            //Destruindo o projétil
            Destroy(gameObject);

            //Instancia uma cópa da particula
            GameObject tempFood = Instantiate(_foodExplosion, transform.position, Quaternion.identity);

            //Destroi a cópia
            Destroy(tempFood, 1.2f);
        }

        //Verificando colisão com as paredes
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
