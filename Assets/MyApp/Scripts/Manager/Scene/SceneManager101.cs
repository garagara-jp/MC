using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Testシーンを管理
/// SceneManagerにアタッチ
/// </summary>
public class SceneManager101 : MonoBehaviour
{
    [SerializeField]
    private int playerTotalNumber = 1;
    [SerializeField]
    private Transform playerSpawnPoint;
    [SerializeField]
    private GameObject player;

    private void Awake()
    {
        GameManager.Instance.playerTotalNumber = playerTotalNumber;
        for (int i = 0; i < playerTotalNumber; i++)
        {
            GameManager.Instance.PlayerPrefabTable[i] = player;
        }

        GameManager.Instance.playerSpawnPoint = playerSpawnPoint;
        Debug.Log(GameManager.Instance.playerSpawnPoint);
        GameManager.Instance.SetCurrentState(GameState.Prepare);
    }
}
