using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステートの基底クラス
/// </summary>
public class StateBase : MonoBehaviour
{
    // このステートに遷移する時に一度だけ呼ばれる
    public virtual void Enter() { }

    // このステートである間、毎フレーム呼ばれる
    public virtual void Execute() { }

    // このステートである間、固定感覚で呼ばれる
    public virtual void FixedExecute() { }

    // このステートから他のステートに遷移するときに一度だけ呼ばれる
    public virtual void Exit() { }
}
