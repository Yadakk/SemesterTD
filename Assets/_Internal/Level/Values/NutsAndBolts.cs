using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;

public class NutsAndBolts : MonoBehaviour, ICounterOutput
{
    [SerializeField]
    private int amount;

    public event Action<string> OnOutput;

    public int Amount
    {
        get => amount;
        set
        {
            if (value != amount) OnOutput.Invoke(value.ToString());
            amount = value;
        }
    }

    private void Start()
    {
        OnOutput.Invoke(amount.ToString());
    }
}
