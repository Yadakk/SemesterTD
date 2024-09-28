using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEntryPoint : MonoBehaviour
{
    private static MapProperties selectedMap;

    [SerializeField]
    private GameObject towerPrefab;

    [SerializeField]
    private GameObject healthBarPrefab;

    private void Start()
    {
        var mapManager = GetComponentInChildren<MapManager>();
        mapManager.SelectMap(selectedMap, towerPrefab, healthBarPrefab);
    }

    public static void StaticSetup(MapProperties mapProperties)
    {
        selectedMap = mapProperties;
    }
}