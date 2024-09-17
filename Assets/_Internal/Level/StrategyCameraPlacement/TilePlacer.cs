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

    public void Place(Placeable placeable)
    {
        if (selector.SelectedTile is not PlaceableTile) return;
        var placeableTile = selector.SelectedTile as PlaceableTile;
        placeableTile.TryPlace(placeable);
    }
}
