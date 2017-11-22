using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bulletにアタッチ
/// 対象に与えるダメージを管理
/// </summary>
public class BulletDamageManager : MonoBehaviour
{
    BulletStatusModel model;
    
    private void Start()
    {
        model = GetComponent<BulletStatusModel>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var damageable = col.GetComponent<IDamageable>();
        if (damageable != null)
        {
            var damage = new Damage(model.BulletPower);
            damageable.ApplyDamage(damage);
        }
    }
}
