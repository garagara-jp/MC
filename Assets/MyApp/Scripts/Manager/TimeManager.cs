using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameManagerにアタッチ
/// </summary>
public class TimeManager : SingletonMonoBehaviour<TimeManager>
{
    private float gameStartTime;
    private float elapsedTime;
    private float remainingTime;
    private float limitTime;

    public float GameStartTime { get { return gameStartTime; } }
    public float ElapsedTime { get { return elapsedTime; } }
    public float RemainingTIme { get { return remainingTime; } }

    private void Awake()
    {
        // シングルトンを確立
        if (this != Instance)
        {
            Destroy(this);
            return;
        }
    }

    private void Update()
    {
        if (gameStartTime != 0)
        {
            elapsedTime = Time.time - gameStartTime;
        }
        remainingTime = limitTime - elapsedTime;
    }

    public void StartBattle(float limitTime)
    {
        gameStartTime = Time.time;
        this.limitTime = limitTime;
    }
}