using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    public Transform SpawnPoint;        // Playerが生成されたときの場所と向き
    [HideInInspector]
    public int PlayerNumber;            // Playerの識別番号
    [HideInInspector]
    public GameObject PlayerInstance;   // 管理するPlayerのプレハブ

    private PlayerStatusModel playerStatusModel;
    private PlayerLocomotor playerLocomotor;
    private PlayerAttackManager playerAttackManager;

    public void Setup()
    {
        playerStatusModel = PlayerInstance.GetComponent<PlayerStatusModel>();
        playerLocomotor = PlayerInstance.GetComponent<PlayerLocomotor>();
        playerAttackManager = PlayerInstance.GetComponent<PlayerAttackManager>();

        playerStatusModel.PlayerNumber = PlayerNumber;

        // スクリプトをまたいで、プレイヤー番号が一定であるように設定
        //playerLocomotor.m_PlayerNumber = m_PlayerNumber;
        //playerAttackManager.m_PlayerNumber = m_PlayerNumber;
    }


    // プレイヤーが制御できないゲーム状態に使用
    public void DisableControl()
    {
        playerLocomotor.enabled = false;
        playerAttackManager.enabled = false;
    }


    // プレイヤーが制御可能なゲーム状態に使用
    public void EnableControl()
    {
        playerLocomotor.enabled = true;
        playerAttackManager.enabled = true;
    }

    // 各ゲーム開始時にPlayerをリセット
    public void Reset()
    {
        PlayerInstance.transform.position = SpawnPoint.position;
        PlayerInstance.transform.rotation = SpawnPoint.rotation;

        PlayerInstance.SetActive(false);
        PlayerInstance.SetActive(true);
    }
}
