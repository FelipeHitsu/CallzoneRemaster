using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour {
    
    //Componente de animator
    public Animator _camAnim;
    
    public void screenShake()
    {
        //Ativando a animação
        _camAnim.SetTrigger("isHit");
    } 
}
