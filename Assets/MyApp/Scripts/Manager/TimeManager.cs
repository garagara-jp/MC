using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameManagerにアタッチ
/// </summary>
public class TimeManager : SingletonMonoBehaviour<TimeManager>
{
    private bool isCounting = false;
    private float startTime;
    private float elapsedTime;
    private float remainingTime;
    private float limitTime;

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
        if (isCounting)
        {
            elapsedTime = Time.time - startTime;
        }
        remainingTime = limitTime - elapsedTime;

        if (remainingTime <= 0f)
        {
            FinishCount();
        }
    }

    // カウント開始(外部起動)
    public void StartCount(float limitTime)
    {
        startTime = Time.time;
        this.limitTime = limitTime;
        isCounting = true;
    }

    // カウント終了
    public void FinishCount()
    {
        startTime = 0;
        elapsedTime = 0;
        remainingTime = 0;
        limitTime = 0;
        isCounting = false;
    }
}