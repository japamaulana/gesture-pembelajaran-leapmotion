using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Background Music")]
    public AudioSource musicSource;
    public AudioClip backgroundMusic;

    [Header("Sound Effect")]
    public AudioSource sfxSource;
    public AudioClip successSound;
    public AudioClip failedSound;

    private bool isMusicOn = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    //==========================
    // Background Music
    //==========================

    public void ToggleMusic()
    {
        if (isMusicOn)
        {
            musicSource.Pause();
        }
        else
        {
            musicSource.UnPause();
        }

        isMusicOn = !isMusicOn;
    }

    //==========================
    // Sound Benar
    //==========================

    public void PlaySuccess()
    {
        sfxSource.PlayOneShot(successSound);
    }

    //==========================
    // Sound Salah
    //==========================

    public void PlayFailed()
    {
        sfxSource.PlayOneShot(failedSound);
    }
}
