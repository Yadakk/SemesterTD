using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(ICounterOutput))]
public class Counter : MonoBehaviour
{
    private TextMeshProUGUI tmpu;

    private ICounterOutput counterOutput;

    private void Awake()
    {
        tmpu = GetComponentInChildren<TextMeshProUGUI>();
        counterOutput = GetComponent<ICounterOutput>();
        counterOutput.OnOutput += OnOutputHandler;
    }

    private void OnOutputHandler(string value)
    {
        tmpu.text = value;
    }

}