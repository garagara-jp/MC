using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyValueSetter : MonoBehaviour, IHaveMoney
{
    MoneyStatusModel moneyStatusModel;

    private void Start()
    {
        moneyStatusModel = GetComponent<MoneyStatusModel>();
    }

    public void SetMoneyValue(float moneyValue)
    {
        moneyStatusModel.MoneyValue = moneyValue;
    }
}
