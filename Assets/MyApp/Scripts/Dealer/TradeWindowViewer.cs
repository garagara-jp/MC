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
    private SpriteRenderer popup;

    private void Start()
    {
        dealerStatusModel = GetComponent<DealerStatusModel>();
        popup.enabled = false;
    }

    private void Update()
    {
        if (dealerStatusModel.isShowWindow && Input.GetKeyDown(KeyCode.Escape))
        {
            dealerStatusModel.isShowWindow = false;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            ShowWindowCmd();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            popup.enabled = false;
        }
    }

    private void ShowWindowCmd()
    {
        popup.enabled = true;

        if (Input.GetKeyDown(KeyCode.I))
        {
            dealerStatusModel.isShowWindow = true;
        }
    }
}
