using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager Instance;

    public int SceneMusic = 0;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play("Ambiente");
    }

    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            Play("Pasos");
        }

        if (Input.GetKeyUp("w"))
        {
            Stop("Pasos");
        }

        if (Input.GetKeyDown("a"))
        {
            Play("Pasos");
        }

        if (Input.GetKeyUp("a"))
        {
            Stop("Pasos");
        }

        if (Input.GetKeyDown("s"))
        {
            Play("Pasos");
        }

        if (Input.GetKeyUp("s"))
        {
            Stop("Pasos");
        }
        if (Input.GetKeyDown("d"))
        {
            Play("Pasos");
        }

        if (Input.GetKeyUp("d"))
        {
            Stop("Pasos");
        }

        if (Input.GetKey("space"))
        {
            Stop("Pasos");
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s?.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

}
