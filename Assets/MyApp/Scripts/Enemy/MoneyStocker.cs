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
    private List<GameObject> moneyPrefabs;  // cloneするMoneyプレハブのList
    private List<GameObject> _moneyPregabs = new List<GameObject>();
    private bool prefabIsSet;


    private void Start()
    {
        enemyStatusModel = GetComponent<EnemyStatusModel>();
        prefabIsSet = false;

        for (int i = 0; i < moneyPrefabs.Count; i++)
        {
            // MoneyプレハブをInstantiate
            var money = Instantiate(moneyPrefabs[i], transform.position, transform.rotation);
            money.transform.parent = transform;
            money.name = gameObject.name + "_" + moneyPrefabs[i].name;

            // プレハブの描写をOFF
            money.GetComponent<SpriteRenderer>().enabled = false;

            // プレハブのRigidbodyをOFF
            money.GetComponent<Rigidbody2D>().simulated = false;

            // Cloneしたプレハブを一旦Listに格納
            _moneyPregabs.Add(money);
        }
    }

    private void Update()
    {
        // CloneしたプレハブをModelのListに追加
        if (!prefabIsSet)
        {
            enemyStatusModel.MoneyPrefabs = _moneyPregabs;
            prefabIsSet = true;
        }
    }
}
