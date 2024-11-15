using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    private AudioSource source;
    public bool loop;
    public static float volume;
    public void SetSource(AudioSource s)
    {
        source = s;
        source.clip = clip;
        source.loop = loop;
    }

    public void SetVolume(float Volumn)
    {
        volume = Volumn;
        source.volume = Volumn;
    }

    public float GetVolume()
    {
        return volume;
    }

    public void Play()
    {
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }

    public void SetLoop()
    {
        source.loop = true;
    }

    public void StopLoop()
    {
        source.loop = false;
    }
}

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    public Sound[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<sounds.Length; i++)
        {
            GameObject SoundObject = new GameObject(sounds[i].name);
            sounds[i].SetSource(SoundObject.AddComponent<AudioSource>());
            SoundObject.transform.SetParent(transform);
        }
    }

    public void SetVolume(float voulmn)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].SetVolume(voulmn);
        }
    }

    public float GetVolume()
    {
        return sounds[0].GetVolume();
    }

    public void Play(string name)
    {
        for(int i=0;i<sounds.Length;i++)
        {
            if (name == sounds[i].name)
            {
                sounds[i].Play();
                return;
            }
        }
    }
    public void Stop(string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (name == sounds[i].name)
            {
                sounds[i].Stop();
                return;
            }
        }
    }

    public void SetLoop(string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (name == sounds[i].name)
            {
                sounds[i].SetLoop();
                return;
            }
        }
    }

    public void StopLoop(string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (name == sounds[i].name)
            {
                sounds[i].StopLoop();
                return;
            }
        }
    }
}
