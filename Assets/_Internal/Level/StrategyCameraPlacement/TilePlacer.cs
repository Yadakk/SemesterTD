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
        var placeableTile = selector.SelectedTile;
        if (!placeable.CanPlaceOn.HasFlag(placeableTile.Type)) return;
        placeableTile.TryPlace(placeable);
    }
}
