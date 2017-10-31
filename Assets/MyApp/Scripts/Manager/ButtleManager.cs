using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtleManager : MonoBehaviour
{
    TimeManager timeManager;

    [SerializeField]
    private bool gameStart = false;
    [SerializeField]
    private float limitTime = 180;
    [SerializeField]
    private bool pause;

    private void Start()
    {
        timeManager = GetComponent<TimeManager>();
    }

    private void Update()
    {
        if (gameStart)
        {
            timeManager.StartGame(limitTime);
            gameStart = false;
        }

        if (pause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
