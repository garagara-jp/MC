using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステート: 徘徊
/// </summary>
public class StateWander : StateBase
{
    [SerializeField]
    StateMachine stateMachine;
    [SerializeField]
    StateAttack stateAttack;

    private Vector3 targetPosition;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float pursuitSqrDistance = 2500f;
    [SerializeField]
    private float margin = 50f;
    [SerializeField]
    private float changeTargetSqrDistance = 40f;
    [SerializeField]
    private float rotationSmooth = 1f;
    [SerializeField]
    private float moveSpeed = 10f;

    public override void Enter()
    {
        // 始めの目標地点を設定する
        targetPosition = GetRandomPositionOnLevel();
        //Debug.Log("Wanderステートに遷移しました");
    }

    public override void Execute()
    {
        // プレイヤーとの距離が小さければ、攻撃ステートに遷移
        float sqrDistanceToPlayer = Vector3.SqrMagnitude(transform.position - player.transform.position);
        if (sqrDistanceToPlayer < pursuitSqrDistance - margin)
        {
            stateMachine.ChangeState(stateAttack);
        }

        // 目標地点との距離が小さければ、次のランダムな目標地点を設定する
        float sqrDistanceToTarget = Vector3.SqrMagnitude(transform.position - targetPosition);
        if (sqrDistanceToTarget < changeTargetSqrDistance)
        {
            targetPosition = GetRandomPositionOnLevel();
        }

        // 目標地点の方向を向く
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);

        // 前方に進む
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    public override void Exit() { }

    public Vector3 GetRandomPositionOnLevel()
    {
        float levelSize = 200f;
        return new Vector3(Random.Range(-levelSize, levelSize),
            Random.Range(25, levelSize),
            Random.Range(-levelSize, levelSize));
    }
}