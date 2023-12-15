using UnityEngine;

[System.Serializable]
public class Sound
{
    public string Name = "";

    public AudioClip Clip;

    [Range(0f, 1f)] public float Volume = 0.0f;
    [Range(0.1f, 3.0f)] public float Pitch = 0.0f;

    public bool Loop = false;

    [HideInInspector] public AudioSource Source;
}
