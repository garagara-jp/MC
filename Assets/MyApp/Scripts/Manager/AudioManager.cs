using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    [HideInInspector]
    public List<AudioSource> BGMTable;
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

    public void SetBGM(AudioSource bgm)
    {
        var isListed = false;
        foreach (var bgmInTable in BGMTable)
        {
            isListed = (bgm == bgmInTable) ? true : false;
        }
        BGMTable.Add(bgm);
    }

    public void PlayBGM(AudioSource bgm)
    {
        currentBGM = bgm;
        currentBGM.Play();
    }
}
