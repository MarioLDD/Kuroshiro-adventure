using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem_Enemy : HealthSystem
{
    public static event Action OnEnemyHealthZero;

    protected override void OnHealthZero()
    {
        base.OnHealthZero();
        OnEnemyHealthZero?.Invoke();
    }
}