using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemyにアタッチ
/// Enemyが保持するMoneyのオブジェクトを指定
/// </summary>
public class MoneyStocker : MonoBehaviour
{
    EnemyStatusModel model;
    [SerializeField]
    private List<GameObject> clonePrefabs;  // Clone対象となるMoneyプレハブのList
    [SerializeField]
    private List<GameObject> moneyPrefabs;  // 実際にcloneするMoneyプレハブのList
    private List<GameObject> _moneyPregabs = new List<GameObject>();
    private bool prefabIsSet;


    private void Start()
    {
        model = GetComponent<EnemyStatusModel>();
        prefabIsSet = false;

        foreach(var prefab in clonePrefabs)
        {
            
        }

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
            model.MoneyPrefabs = _moneyPregabs;
            prefabIsSet = true;
        }
    }
}
