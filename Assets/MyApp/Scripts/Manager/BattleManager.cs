﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SceneManagerにアタッチ
/// Battleステート中の諸々を管理
/// </summary>
public class BattleManager : MonoBehaviour
{
    [SerializeField]
    private bool battleIsStarted = true;
    private bool _battleIsStarted = false;

    [SerializeField]
    private float limitTime = 180;

    public bool DoSpawn { get; set; }
    public bool IsPause { get; set; }

    private void Start()
    {
        DoSpawn = false;
        IsPause = false;
    }

    private void Update()
    {
        if (battleIsStarted && !_battleIsStarted)
        {
            GameManager.Instance.SetCurrentState(GameState.Battle);
            TimeManager.Instance.StartBattle(limitTime);
            _battleIsStarted = true;
        }

        // バトル開始処理
        if (GameManager.Instance.currentGameState == GameState.Battle)
        {
            DoSpawn = true;
        }

        // ポーズ処理
        if (IsPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    private void OnGUI()
    {
        //var startButton = GUI.Button(new Rect(20, 20, 100, 40), "Start");
        //if (startButton)
        //{
        //    GameManager.Instance.SetCurrentState(GameState.Battle);
        //    TimeManager.Instance.StartBattle(limitTime);
        //}
    }
}
