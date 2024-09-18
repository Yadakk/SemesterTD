using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEntryPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject[] maps;

    private void Start()
    {
        var mapManager = GetComponentInChildren<MapManager>();
        mapManager.SelectMap(maps[0]);
    }
}