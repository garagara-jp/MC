using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Dealerにアタッチ
/// </summary>
public class TradeWindowViewer : MonoBehaviour
{
    DealerStatusModel dealerStatusModel;

    [SerializeField]

    private void Start()
    {
        dealerStatusModel = GetComponent<DealerStatusModel>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            ShowWindowCmd();
        }
    }

    private void ShowWindowCmd()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            dealerStatusModel.isShowWindow = true;
        }
    }
}
