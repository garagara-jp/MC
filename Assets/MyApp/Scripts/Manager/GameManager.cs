using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum GameState
{
    Title,
    Prepare,
    Battle,
    Result,
    Test
}

/// <summary>
/// ゲーム全体の進行を管理するGameManager
/// シングルトンパターンで作成playerAttackManager
/// </summary>
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    private int[] playerNumber = { 1, 2, 3, 4 };

    [HideInInspector]
    public int playerTotalNumber = 1;   // ゲームの参加人数
    [HideInInspector]
    public Transform playerSpawnPoint;  // プレイヤーのスポーン位置(SceneManagerから受け取る)

    // Playerとデバイスそれぞれの番号の対応関係を表すテーブル
    // TKey: Playerの番号(1~4)
    // TValue: Deviceの番号(DeviceManagerから与えられる)
    public IDictionary<int, int> DeviceNumberTable = new Dictionary<int, int>();
    // PlayerNumberとプレハブの対応関係を表すテーブル
    // TKey: Playerの番号(1~4)
    // TValue: PlayerのPrefab(該当Managerから与えられる)
    public IDictionary<int, GameObject> PlayerPrefabTable = new Dictionary<int, GameObject>();

    public List<PlayerManager> PlayerManagerList = new List<PlayerManager>();

    public GameState currentGameState;

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

    // 外からこのメソッドを利用して状態を変更
    public void SetCurrentState(GameState state)
    {
        Debug.Log("Called SetCurrentState(" + state + ")");
        currentGameState = state;
        Debug.Log("CurrentState is " + currentGameState);
        OnGameStateChanged(currentGameState);
    }

    // 状態が変わった際の挙動を定義
    void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Title:
                //StartAction();
                break;
            case GameState.Prepare:
                SpawnAllPlayer();
                break;
            case GameState.Battle:
                break;
            case GameState.Result:
                //EndAction();
                break;
            case GameState.Test:
                SpawnAllPlayer();
                break;
            default:
                break;
        }
    }

    private void SpawnAllPlayer()
    {
        // プレイヤーの参加人数分だけPlayerManagerを作成
        for (int i = 0; i < playerTotalNumber; i++)
        {
            PlayerManagerList.Add(new PlayerManager());
        }

        for (int i = 0; i < PlayerManagerList.Count; i++)
        {
            PlayerManagerList[i].SpawnPoint = playerSpawnPoint;

            // PlayerのInstanceを作って、制御に必要なプレイヤー番号と参照を設定
            PlayerManagerList[i].PlayerInstance = Instantiate(PlayerPrefabTable[i],
                                                        PlayerManagerList[i].SpawnPoint.position,
                                                        PlayerManagerList[i].SpawnPoint.rotation);
            PlayerManagerList[i].PlayerNumber = playerNumber[i];
            PlayerManagerList[i].Setup();
            Debug.Log(playerNumber[i] + "番のプレイヤーをセットアップ");
        }
    }
}
