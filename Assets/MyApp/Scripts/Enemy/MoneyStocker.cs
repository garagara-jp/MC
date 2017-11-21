using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemyにアタッチ
/// Enemyが保持するMoneyのオブジェクトを指定
/// </summary>
public class MoneyStocker : MonoBehaviour
{
    EnemyStatusModel enemyStatusModel;
    [SerializeField]
    private List<GameObject> moneyPrefabs;

    private void Start()
    {
        enemyStatusModel = GetComponent<EnemyStatusModel>();
        enemyStatusModel.MoneyPrefabs = moneyPrefabs;

        if (moneyPrefabs.Count== 0)
            return;

        for (int i = 0; i < moneyPrefabs.Count; i++)
        {
            var money = Instantiate(moneyPrefabs[i], transform.position, transform.rotation);
            money.transform.parent = transform;
            money.name = gameObject.name + "_" + moneyPrefabs[i].name;
        }
    }
}
