﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Destructable {

    [SerializeField]
    private float inSeconds;

    public override void Die()
    {
        base.Die();

        GameManager.Instance.Respawner.Despawn(gameObject, inSeconds);

        print("We died");
    }

    void OnEnable()
    {
        Reset();
    }

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        print("Remaining: " + HitPointsRemaining);
    }
}
