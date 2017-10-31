using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステート: 徘徊
/// </summary>
public class StateWander : StateBase
{
    EnemyStatusModel model;
    StateMachine stateMachine;
    StateAttack stateAttack;

    private Vector3 targetPosition;

    public override void Enter()
    {
        model = GetComponent<EnemyStatusModel>();
        stateMachine = GetComponent<StateMachine>();
        stateAttack = GetComponent<StateAttack>();

        // 始めの目標地点を設定する
        targetPosition = GetTargetPositionOnLevel();
        //Debug.Log("Wanderステートに遷移しました");
    }

    public override void Execute()
    {
        // 目標地点まで来たら攻撃ステートに遷移
        if (Vector2.SqrMagnitude(transform.position - targetPosition) < 0.1f)
        {
            stateMachine.ChangeState(stateAttack);
        }

        // 目標地点まで進む
        var targetVec = Vector3.Normalize(targetPosition - transform.position);
        transform.Translate(targetVec * model.MoveSpeed * Time.deltaTime);
    }

    public override void Exit() { }

    public Vector3 GetTargetPositionOnLevel()
    {
        return new Vector2(Random.Range(-6.0f, 8.5f), Random.Range(2.7f, 3.3f));
    }
}