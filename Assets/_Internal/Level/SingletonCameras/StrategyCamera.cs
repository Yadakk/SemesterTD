using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategyCamera : MonoBehaviour
{
    public static Camera Camera { get; private set; }

    private void Awake()
    {
        Camera = GetComponent<Camera>();
    }
}
