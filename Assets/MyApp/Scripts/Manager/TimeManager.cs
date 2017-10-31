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

    public float GameStartTime { get { return gameStartTime; } }
    public float ElapsedTime { get { return elapsedTime; } }
    public float RemainingTIme { get { return remainingTime; } }

    private void Update()
    {
        elapsedTime = Time.time - gameStartTime;
        remainingTime -= elapsedTime;
    }

    public void StartGame(float limitTime)
    {
        gameStartTime = Time.time;
        remainingTime = limitTime;
    }


}