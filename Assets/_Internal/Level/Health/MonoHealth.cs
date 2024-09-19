using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100f;

    private float health;

    public event Action<float> OnValueChanged;

    public float MaxHealth => health;

    public float Health
    {
        get => health;
        set
        {
            if (value <= 0)
            {
                Destroy(gameObject);
                return;
            }

            if (value != health) OnValueChanged.Invoke(value);
            health = value;
        }
    }

    private void Start()
    {
        health = maxHealth;
    }
}
