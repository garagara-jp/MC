using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageManager : MonoBehaviour
{
    BulletStatusModel model;

    private void Start()
    {
        model = GetComponent<BulletStatusModel>();
    }

    private void FixedUpdate()
    {
        if (model.ShootOwnerTagName != null)
            GetComponent<CircleCollider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // 弾が射出したGameObjectにダメージ判定を適用しないように判定
        if (col.gameObject.tag == model.ShootOwnerTagName)
        { 
            return;
        }

        var damageable = col.GetComponent<IDamageable>();
        if (damageable != null)
        {
            var damage = new Damage(model.BulletPower);
            damageable.ApplyDamage(damage);
        }
    }
}
