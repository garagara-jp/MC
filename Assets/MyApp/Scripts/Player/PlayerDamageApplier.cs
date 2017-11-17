using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageApplier : MonoBehaviour, IDamageable
{
    PlayerStatusModel model;

    private void Start()
    {
        model = GetComponent<PlayerStatusModel>();
    }

    public void ApplyDamage(Damage damage)
    {
        model.HitPoint -= damage.DamageAmount;
        //Debug.Log(gameObject.tag + " Left HP : " + model.HitPoint);
    }
}
