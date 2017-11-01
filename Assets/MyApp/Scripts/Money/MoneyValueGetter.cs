using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moneyにアタッチ
/// MoneyのValueをインターフェース越しに渡す
/// </summary>
public class MoneyValueGetter : MonoBehaviour, IGetableMoney
{
    MoneyStatusModel moneyStatusModel;

    private void Start()
    {
        moneyStatusModel = GetComponent<MoneyStatusModel>();
    }

    public float GetMoneyValue()
    {
        return moneyStatusModel.MoneyValue;
    }
}
