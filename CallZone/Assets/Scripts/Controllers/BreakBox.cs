using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBox : MonoBehaviour {

    //Vida da caixa
    private int _boxLife = 4;

    //Animação da caixa
    private Animator _boxAnim;

    void Start()
    {
        //Pegando o componente do filho para animar
        _boxAnim = GetComponentInChildren<Animator>();
        
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Se colidir com o projétil, perde vida e muda a sprite
        if(other.gameObject.CompareTag("Bullet"))
        {
            //Perdendo vida
            Debug.Log("vidinha da caixa:" + _boxLife);

            //Dizendo que o valor da vida é igual para a animação
            _boxAnim.SetInteger("_LifeBox", _boxLife);
            _boxLife -= 1;

            //Se zerar a vida, destroi 
            if (_boxLife <= 0)
                Destroy(gameObject);
        }
    }
}
