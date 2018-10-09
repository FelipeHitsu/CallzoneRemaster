using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioClip[] sounds;

    private AudioSource player;
   
	// Use this for initialization
	void Start () {
        player = GetComponent<AudioSource>();
	}
	
	//Tocar som
    public void Playsound(int index)
    {
        player.clip = sounds[index];
        player.Play();
    }

    //Parar som
    public void StopSound(int index)
    {
        player.clip = sounds[index];
        player.Play();
    }

    //Colocar em loop
    public void OnLoop(int index)
    {
        player.clip = sounds[index];
        player.loop = true;
        player.Play();
    }

    //Parar o loop
    public void StopLoop(int index)
    {
        player.clip = sounds[index];
        player.loop = false;
        player.Pause();
    }

}
