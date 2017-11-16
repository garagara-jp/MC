﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Title,
    Prepare,
    Battle,
    End
}

/// <summary>
/// ゲーム全体の進行を管理するGameManager
/// シングルトンパターンで作成
/// </summary>
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    private GameState currentGameState;

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

    void Start()
    {

    }

}
