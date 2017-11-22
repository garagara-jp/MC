using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SceneManagerにアタッチ
/// Battleステート中の諸々を管理
/// </summary>
public class BattleManager : MonoBehaviour
{
    private List<bool> playerIsDead = new List<bool>();

    [SerializeField]
    private bool battleIsStarted = false;
    private bool _battleIsStarted = false;

    [SerializeField]
    private float limitTime = 180;

    public bool DoSpawn { get; set; }
    public bool IsPause { get; set; }
    public bool BattleIsStarted
    {
        get { return battleIsStarted; }
        set { battleIsStarted = value; }
    }

    private void Start()
    {
        DoSpawn = false;
        IsPause = false;

    }

    private void Update()
    {
        // バトル開始処理
        if (BattleIsStarted && !_battleIsStarted)
        {
            // GameStateをセット
            GameManager.Instance.SetCurrentState(GameState.Battle);
            // ゲームカウントを開始
            TimeManager.Instance.StartCount(limitTime);
            // 各プレイヤーの生死状態を配列に格納
            for (int i = 0; i < GameManager.Instance.PlayerManagerList.Count; i++)
            {
                playerIsDead.Add(GameManager.Instance.PlayerManagerList[i].PlayerInstance.GetComponent<PlayerStatusModel>().IsDead);
            }

            _battleIsStarted = true;
            return;
        }

        // バトル中の処理
        if (GameManager.Instance.currentGameState == GameState.Battle)
        {
            DoSpawn = true;

            // バトル終了処理
            if (TimeManager.Instance.RemainingTIme <= 0 || CheckAllPlayerDeath())
            {
                GameManager.Instance.SetCurrentState(GameState.Result);
                DoSpawn = false;
                IsPause = true;
                Debug.Log("バトル終了！");
            }
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

    private bool CheckAllPlayerDeath()
    {
        var allPlayerIsDead = true;
        for (int i = 0; i < playerIsDead.Count; i++)
        {
            if (!playerIsDead[i])
                allPlayerIsDead = false;
        }

        return allPlayerIsDead;
    }
}
