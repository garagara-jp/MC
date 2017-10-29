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
        Debug.Log(gameObject.tag + " Left HP : " + model.HitPoint);
    }
}
