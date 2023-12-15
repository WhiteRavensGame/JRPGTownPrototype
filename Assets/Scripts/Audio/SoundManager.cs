using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Sound List")]
    [SerializeField] private Sound[] sounds;

    private void Awake()
    {
        foreach (var sound in sounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;

            sound.Source.volume = sound.Volume;
            sound.Source.pitch = sound.Pitch;
            sound.Source.loop = sound.Loop;
        }
    }

    public void Play(string name)
    {
        Sound mySound = Array.Find(sounds, sound => sound.Name == name);

        if (mySound != null)
        {
            mySound.Source.Play();
        }
        else
        {
            Debug.Log("Sound Not Found");
        }
    }
}
