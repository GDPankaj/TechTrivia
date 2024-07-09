using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioClip musicClip;
    [SerializeField] AudioSource sfxsource;

    private void Start()
    {
        PlayBackgroundMusic();
    }

    void PlayBackgroundMusic()
    {
        if(musicClip != null)
        {
            musicSource.clip = musicClip;
            musicSource.loop = true;
            musicSource.Play();
        }
        else
        {
            Debug.Log("Add Backgroundmusic please");
        }
        
    }

    public void PlaySFX(AudioClip sfx)
    {
        if (sfx != null && sfxsource != null)
        {

        }
        sfxsource.PlayOneShot(sfx);
    }
}
