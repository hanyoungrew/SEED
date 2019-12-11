using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public AudioMixerGroup musicGroup;
    public AudioMixerGroup sfxGroup;

    public AudioSource music;
    // Use this for initialization
    
    void Awake()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().audiomanager = this; 
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();

            sound.source.clip = sound.clip;

            if (sound.group == "Music")
            {
                sound.source.outputAudioMixerGroup = musicGroup;
                sound.source.loop = true;
                sound.source.playOnAwake = true;
            }
            else if (sound.group == "SFX")
            {
                sound.source.outputAudioMixerGroup = sfxGroup;
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        Play("GameStart");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            //Debug.Log("No music");
            return;
        }
        if (name == "RoundSong"){
            //Debug.Log("music");
            music = s.source;
        }
        s.source.Play();
        
    }

    public bool IsPlaying(string audio)
    {
        Sound s = Array.Find(sounds, sound => sound.name == audio);
        if (s != null && s.source.isPlaying)
        {
            //Debug.Log("playing clip");
            return true;
        }
        else
        {
            //Debug.Log("not playing");
            return false;
        }
    }

    public void Stop(string audioClip)
    {
        Sound s = Array.Find(sounds, sound => sound.name == audioClip);
        if (s != null && s.source.isPlaying)
        {
            s.source.Stop();
        }
    }

    public void StopMusic(){
        music.Stop();
    }
}
