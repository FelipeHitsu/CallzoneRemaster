using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioController : MonoBehaviour
{

    [System.Serializable]
    public class AudioGroup
    {
        public string name;
        public List<AudioClip> clips;

        [HideInInspector]
        public AudioSource player;
    }

    public List<AudioGroup> AudiosGroup;
    

   
	
	void Start ()
    {
        //Cria todos os audioSources necessários
        for (int i = 0; i < AudiosGroup.Count; i++)
        {
            AudiosGroup[i].player = gameObject.AddComponent<AudioSource>();
        }
    }

    //Verifica se está tocando
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

    //Controle de volume
    public void VolumeController(int group, float volume)    
    {
        AudiosGroup[group].player.volume = volume;
    }

    
}
