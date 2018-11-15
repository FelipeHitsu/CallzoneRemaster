using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour {
    
    //Componente de animator
    public Animator _camAnim;

	void Update ()
    {
		
	}

    public void screenShake()
    {
        //Ativando a animação
        _camAnim.SetBool("isHit", true);
    } 
}
