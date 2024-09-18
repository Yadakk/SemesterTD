using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEntryPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject[] maps;

    private void Awake()
    {
        var mapManager = GetComponentInChildren<MapManager>();
        //mapManager.GenerateMap(maps)
    }
}
