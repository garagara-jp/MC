using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameManagerにアタッチ
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    GameStatusModel gameStatusModel;

    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private Transform spawnPlace;

    private void Start()
    {
        gameStatusModel = GetComponent<GameStatusModel>();

        // コルーチンを設定
        StartCoroutine(SpawnEnemy(gameStatusModel.EnemySpawnInterval));
    }

    private IEnumerator SpawnEnemy(float second)
    {
        while (true)
        {
            while (gameStatusModel.DoSpawn)
            {
                var enemy = Instantiate(enemyPrefab, spawnPlace.position, spawnPlace.rotation);
                yield return new WaitForSeconds(second);
            }

            yield return new WaitForSeconds(second);
        }
    }
}
