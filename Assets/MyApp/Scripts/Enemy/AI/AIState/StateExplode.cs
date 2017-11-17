using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステート: 爆発
/// </summary>
public class StateExplode : StateBase
{
    public override void Enter()
    {
        //Debug.Log("Explodeステートに遷移しました");

        // 1秒後に自身を消去する
        Destroy(gameObject, 1.0f);
    }

    public override void Execute() { }

    public override void Exit() { }
}
