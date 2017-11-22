using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// GameManagerにアタッチ
/// </summary>
public class UIManager : MonoBehaviour
{
    private List<PlayerStatusModel> playerStatusModels = new List<PlayerStatusModel>();
    DealerStatusModel dealerStatusModel;

    [SerializeField]
    private Text playerGoldValue;
    [SerializeField]
    private Text limitTImeValue;
    [SerializeField]
    private Image[] playerLifeValues;

    //[SerializeField]
    //private GameObject tradeWindow;

    private void Start()
    {
        for (int i = 0; i < GameManager.Instance.playerTotalNumber; i++)
        {
            playerStatusModels.Add(GameManager.Instance.PlayerManagerList[i].PlayerInstance.GetComponent<PlayerStatusModel>());
        }

        for (int i = 0; i < playerLifeValues.Length; i++)
        {
            playerLifeValues[i].enabled = false;
        }

        //tradeWindow.SetActive(false);
    }

    private void Update()
    {
        // Playerの所持金と残り時間を表示
        playerGoldValue.text = GameManager.Instance.PlayerManagerList[0].PlayerInstance.GetComponent<PlayerStatusModel>().PlayerMoney.ToString();
        limitTImeValue.text = Mathf.CeilToInt(TimeManager.Instance.RemainingTIme).ToString();

        // HPの表示を管理
        var hp = GameManager.Instance.PlayerManagerList[0].PlayerInstance.GetComponent<PlayerStatusModel>().HitPoint;
        var heartNum = (int)hp / 10;
        Debug.Log(heartNum);
        for (int i = 0; i < playerLifeValues.Length; i++)
        {
            if (i <= heartNum - 1) playerLifeValues[i].enabled = true;
            else playerLifeValues[i].enabled = false;
        }

        //// アイテムトレード画面を表示
        //if (dealerStatusModel.isShowWindow)
        //{
        //    tradeWindow.SetActive(true);
        //    gameStatusModel.IsPause = true;
        //}
        //else
        //{
        //    tradeWindow.SetActive(false);
        //    gameStatusModel.IsPause = false;
        //}
    }

    //private void OnGUI()
    //{
    //    GUI.Box(new Rect(20, 100, 100, 30), "HP : " + playerStatusModel.HitPoint.ToString());
    //}
}
