using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playerにアタッチ
/// フィールド上のMoneyを収集
/// </summary>
public class MoneyCollector : MonoBehaviour
{
    PlayerStatusModel playerStatusModel;

    private void Start()
    {
        playerStatusModel = GetComponent<PlayerStatusModel>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var getableMoney = col.gameObject.GetComponent<IGetableMoney>();
        if (getableMoney != null)
        {
            playerStatusModel.PlayerMoney += getableMoney.GetMoneyValue();
            Destroy(col.gameObject);
            //Debug.Log("Now PlayerMoney is " + playerStatusModel.PlayerMoney);
        }
    }
}
