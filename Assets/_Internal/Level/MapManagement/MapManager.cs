using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    public void SelectMap(GameObject prefab)
    {
        GameObject map = Instantiate(prefab, transform);
        var dataExtractor = map.GetComponentInChildren<MapDataExtractor>();
        MapData mapData = dataExtractor.ExtractData();
    }
}
