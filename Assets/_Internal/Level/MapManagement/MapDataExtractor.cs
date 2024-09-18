using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class MapDataExtractor : MonoBehaviour
{
    private Tilemap tilemap;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }

    public MapData ExtractData()
    {
        return new MapData(tilemap.GetComponentsInChildren<MapTile>());
    }
}
