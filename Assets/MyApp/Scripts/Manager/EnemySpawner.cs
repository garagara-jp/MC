using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameManagerにアタッチ
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private Transform spawnPlace;
    [SerializeField]
    private bool doSpawn = true;
    [SerializeField]
    private float spawnInterval = 1f;   //秒

    private void Start()
    {
        // コルーチンを設定
        StartCoroutine(SpawnEnemy(spawnInterval));
    }

    private IEnumerator SpawnEnemy(float second)
    {
        // ループ
        while (doSpawn)
        {
            var enemy = Instantiate(enemyPrefab, spawnPlace.position, spawnPlace.rotation);
            yield return new WaitForSeconds(second);
        }
    }
}
