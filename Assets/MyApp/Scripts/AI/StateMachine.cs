using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステートマシーン
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

    public void Update()
    {
        if (currentState != null)
        {
            currentState.Execute();
        }
    }

    public void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.FixedExecute();
        }
    }
}
