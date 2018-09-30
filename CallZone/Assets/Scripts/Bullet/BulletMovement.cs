using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    
    //Velocidade de movimento do projetil
    public float speed;

    public Rigidbody2D bulletRb;

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
            //Destruindo o objeto, no caso o projétil
            Destroy(gameObject);
        }

        //Verificando se houve colisão com o jogador adversário e chamando a função que aplica o dano
        if (other.gameObject.CompareTag("Player"))
        {
            //Pegando o componente do tank para chamar a função de dano com o valor
            other.collider.GetComponent<PlayerTank>().ApplyDamage(10);

            //Destruindo o projétil
            Destroy(gameObject);
        }

        
    }

    

}
