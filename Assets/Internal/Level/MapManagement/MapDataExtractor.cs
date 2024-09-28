using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDataExtractor : MonoBehaviour
{
    public MapData ExtractData()
    {
        return new MapData(GetComponentsInChildren<MapTile>());
    }
}
