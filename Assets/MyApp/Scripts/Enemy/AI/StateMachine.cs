using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemyにタッチする
/// ステートマシーンとしてステートの変更を管理
/// </summary>
public class StateMachine : MonoBehaviour
{
    private StateBase currentState;

    public StateMachine()
    {
        currentState = null;
    }

    public StateBase CurrentState
    {
        get { return currentState; }
    }

    public void ChangeState(StateBase state)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = state;
        currentState.Enter();
        //Debug.Log($"ステートマシーンにより{state}ステートに変更されました");
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.Execute();
        }
    }

    private void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.FixedExecute();
        }
    }
}
