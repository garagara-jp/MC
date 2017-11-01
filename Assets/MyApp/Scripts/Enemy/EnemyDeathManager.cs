using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemyにアタッチ
/// HPが0になったときの処理を管理
/// </summary>
public class EnemyDeathManager : MonoBehaviour
{
    EnemyStatusModel enemyStatusModel;

    private void Start()
    {
        enemyStatusModel = GetComponent<EnemyStatusModel>();
    }

    private void Update()
    {
        if (enemyStatusModel.IsDead && !enemyStatusModel.IsHaveMoney)
        {
            Destroy(gameObject);
            Debug.Log("死にました");
        }
    }
}
