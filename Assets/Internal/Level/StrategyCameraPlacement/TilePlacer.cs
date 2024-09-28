using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(StrategyCameraTileSelector))]
public class TilePlacer : MonoBehaviour
{
    private StrategyCameraTileSelector selector;

    private void Awake()
    {
        selector = GetComponent<StrategyCameraTileSelector>();
    }

    public void Place(BuildingLevels buildings)
    {
        var placeableTile = selector.SelectedTile;
        var building = buildings.Levels[Random.Range(0, buildings.Levels.Length)];
        if (!building.CanPlaceOn.HasFlag(placeableTile.Type)) return;
        placeableTile.TryPlace(building);
    }
}