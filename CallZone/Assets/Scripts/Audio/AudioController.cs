﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioController : MonoBehaviour {

    

    [System.Serializable]
    public class AudioGroup
    {
        public string name;
        public List<AudioClip> clips;

        [HideInInspector]
        public AudioSource player;
    }

    public List<AudioGroup> AudiosGroup;
    //A source 0 será para efeitos rápidos, como tiro, coletar comida, levar tiro...
    //A source 1 será para efeitos que precisam tocar a todo instante, movimento/parada do "tank"
    //A source 2 será a de musicas

   
	// Use this for initialization
	void Start ()
    {
        
        for (int i = 0; i < AudiosGroup.Count; i++)
        {
            AudiosGroup[i].player = gameObject.AddComponent<AudioSource>();
        }
    }

    public bool AudioIsPlaying(int group, int clipIndex)
    {
        
        return AudiosGroup[group].player.isPlaying;
       
    }

    //Tocar som
    public void Playsound(int group, int clipIndex, bool loop)
    {
        if (clipIndex >= AudiosGroup[group].clips.Count)
            return;

        AudiosGroup[group].player.clip = AudiosGroup[group].clips[clipIndex];
        AudiosGroup[group].player.Play();
        AudiosGroup[group].player.loop = loop;

    }

    //Parar som
    public void StopSound(int indexGroup)
    {
        AudiosGroup[indexGroup].player.Stop();
    }

    public void VolumeController(int group, float volume)    
    {
        AudiosGroup[group].player.volume = volume;
    }
}
