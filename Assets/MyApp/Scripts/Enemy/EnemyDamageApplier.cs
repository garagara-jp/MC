using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageApplier : MonoBehaviour, IDamageable
{
    EnemyStatusModel model;

    private void Start()
    {
        model = GetComponent<EnemyStatusModel>();
    }

    public void ApplyDamage(Damage damage)
    {
        model.HitPoint -= damage.DamageAmount;
        Debug.Log("Attack is Hit : Damage = " + damage.DamageAmount);
        Debug.Log("Left HP : " + model.HitPoint);
    }
}
