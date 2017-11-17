using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameManagerにアタッチ
/// </summary>
public class TimeManager : MonoBehaviour
{
    private float gameStartTime;
    private float elapsedTime;
    private float remainingTime;
    private float limitTime;

    public float GameStartTime { get { return gameStartTime; } }
    public float ElapsedTime { get { return elapsedTime; } }
    public float RemainingTIme { get { return remainingTime; } }

    private void Update()
    {
        if (gameStartTime != 0)
        {
            elapsedTime = Time.time - gameStartTime;
        }
        remainingTime = limitTime - elapsedTime;
    }

    public void StartGame(float limitTime)
    {
        gameStartTime = Time.time;
        this.limitTime = limitTime;
    }
}