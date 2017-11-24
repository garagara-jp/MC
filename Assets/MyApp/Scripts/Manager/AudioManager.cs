using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    [HideInInspector]
    public AudioSource currentBGM;

    private void Awake()
    {
        // シングルトンを確立
        if (this != Instance)
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlayBGM(AudioSource bgm)
    {
        bgm.Play();
    }
}
