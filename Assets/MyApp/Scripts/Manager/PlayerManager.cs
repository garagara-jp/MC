using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    // このクラスはタンクの様々な設定を管理するためのものです。
    // このクラスは GameManager クラスと一緒に使い、タンクの挙動と、プレイヤーがゲームのさまざまな段階で
    // タンクを制御するかを支配します。

    public Transform SpawnPoint;                          // タンクが生成されたときのタンクの場所と向き
    [HideInInspector]
    public int PlayerNumber;            // この番号によってどのプレイヤーのマネージャーかを認識します。
    [HideInInspector]
    public GameObject PlayerInstance;

    private PlayerStatusModel playerStatusModel;
    private PlayerLocomotor playerLocomotor;
    private PlayerAttackManager playerAttackManager;

    public void Setup()
    {
        playerStatusModel = PlayerInstance.GetComponent<PlayerStatusModel>();
        playerLocomotor = PlayerInstance.GetComponent<PlayerLocomotor>();
        playerAttackManager = PlayerInstance.GetComponent<PlayerAttackManager>();

        playerStatusModel.PlayerNumber = PlayerNumber;

        // スクリプトをまたいで、プレイヤー番号が一定であるように設定します。
        //playerLocomotor.m_PlayerNumber = m_PlayerNumber;
        //playerAttackManager.m_PlayerNumber = m_PlayerNumber;
    }


    // プレイヤーが制御できないゲーム状態に使用。
    public void DisableControl()
    {
        playerLocomotor.enabled = false;
        playerAttackManager.enabled = false;
    }


    // プレイヤーが制御可能なゲーム状態に使用。
    public void EnableControl()
    {
        playerLocomotor.enabled = true;
        playerAttackManager.enabled = true;
    }


    // 各ラウンド開始時に使い、タンクをデフォルト状態にします。
    public void Reset()
    {
        PlayerInstance.transform.position = SpawnPoint.position;
        PlayerInstance.transform.rotation = SpawnPoint.rotation;

        PlayerInstance.SetActive(false);
        PlayerInstance.SetActive(true);
    }
}
