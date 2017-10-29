using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemyにアタッチ
/// エネミーのステイトを管理する
/// </summary>
public class EnemyStateManager : MonoBehaviour
{
    StateMachine stateMachine;
    StateWander stateWander;

    private void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        stateWander = GetComponent<StateWander>();
    }

    private void Update()
    {
        if (stateMachine.CurrentState == null)
        {
            stateMachine.ChangeState(stateWander);
        }
    }
}
