using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRock : MonoBehaviour {

   
    public SpriteRenderer _spriteRend;

    public Animator _rockAnim;


	// Use this for initialization
	void Start ()
    {
        _spriteRend = GetComponentInChildren<SpriteRenderer>();
        _rockAnim = GetComponentInChildren<Animator>();
        	
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            _rockAnim.SetBool("isHit", true);
        }
    }
}
