using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBuilding : Building
{
    [SerializeField]
    private float attackIntervalSeconds = 1f;

    [SerializeField]
    private float damage = 20f;

    public float AttackIntervalSeconds => attackIntervalSeconds;
    public float Damage => damage;
}
