using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtleManager : MonoBehaviour
{
    GameStatusModel gameStatusModel;
    TimeManager timeManager;

    private void Start()
    {
        gameStatusModel = GetComponent<GameStatusModel>();
        timeManager = GetComponent<TimeManager>();
    }

    private void Update()
    {
        if (gameStatusModel.IsGameStarted)
        {
            timeManager.StartGame(gameStatusModel.LimitTime);
            gameStatusModel.DoSpawn = true;
            gameStatusModel.IsGameStarted = false;
        }

        if (gameStatusModel.IsPause)
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
        var button = GUI.Button(new Rect(20, 20, 100, 40), "Start");

        if (button)
        {
            gameStatusModel.IsGameStarted = true;
        }
    }
}
