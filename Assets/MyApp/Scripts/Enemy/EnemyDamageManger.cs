using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemyにアタッチ
/// 対象に与えるダメージを管理
/// </summary>
public class EnemyDamageManger : MonoBehaviour
{
    EnemyStatusModel model;

    private void Start()
    {
        model = GetComponent<EnemyStatusModel>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        var damageable = col.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            var damage = new Damage(model.EnemyPower);
            damageable.ApplyDamage(damage);
            Debug.Log("Enemy is attack!!");
        }
    }
}
