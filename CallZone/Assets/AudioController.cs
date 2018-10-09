using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioController : MonoBehaviour {

    public AudioClip[] sounds;

    
    private AudioSource[] player;
    //A source 0 será para efeitos rápidos, como tiro, coletar comida, levar tiro...
    //A source 1 será para efeitos que precisam tocar a todo instante, movimento/parada do "tank"
    //A source 2 será a de musicas

   
	// Use this for initialization
	void Start ()
    {
        player = new AudioSource[sounds.Length];


        for (int i = 0; i < player.Length; i++)
        {
            player[i] = gameObject.AddComponent<AudioSource>();
        }


    }

  
    //Tocar som
    public void Playsound(int indexClip, int indexSource, bool loop)
    {
        player[indexSource].clip = sounds[indexClip];
        player[indexSource].Play();

        if(loop)
        { player[indexSource].loop = true; }
    }

    //Parar som
    public void StopSound(int indexClip, int indexSource)
    {
        player[indexSource].clip = sounds[indexClip];
        player[indexSource].Play();
    }


}
