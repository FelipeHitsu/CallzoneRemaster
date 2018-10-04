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
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Playsound(int index)
    {
        player.clip = sounds[index];
        player.Play();
    } 

    //public void OnLoop (AudioClip genericSound)
    //{
    //    sounds.clip = genericSound;
    //    sounds.loop = true;
    //}

    //public void StopLoop(AudioClip genericSound)
    //{
    //    sounds.clip = genericSound;
    //    sounds.loop = false;
    //}

}
