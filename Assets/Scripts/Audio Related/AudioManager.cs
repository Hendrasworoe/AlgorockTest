using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance { get { return _instance; } }

    [SerializeField] private List<SoundData> musicList;
    [SerializeField] private List<SoundData> sfxList;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayMusic(string musicName)
    {
        SoundData s = musicList.Find(x => x.soundName.Equals(musicName));

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.soundClip;
            musicSource.Play();
        }
    }

    public void PlaySfx(string sfxName)
    {
        SoundData s = sfxList.Find(x => x.soundName.Equals(sfxName));

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.PlayOneShot(s.soundClip);
        }
    }
}
