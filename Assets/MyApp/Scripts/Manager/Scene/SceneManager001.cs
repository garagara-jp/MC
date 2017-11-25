using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager001 : MonoBehaviour
{
    [SerializeField]
    AudioSource bgm;

    private void Awake()
    {
        GameManager.Instance.SetCurrentState(GameState.Title);
    }

    private void Start()
    {
        AudioManager.Instance.PlayBGM(bgm);
    }
}
