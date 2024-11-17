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
        //볼륨값 세이브했다가 게임꺼도 저장되게 하는 파트.
        float savedVolume = PlayerPrefs.GetFloat("SoundVolume", 1.0f); // 기본값 1.0
        Sound.volume = savedVolume;
        //여기까지 (현재 유니티엔진에서 게임 켜고끌때는 적용안되는듯함)

        for (int i=0;i<sounds.Length; i++)
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
