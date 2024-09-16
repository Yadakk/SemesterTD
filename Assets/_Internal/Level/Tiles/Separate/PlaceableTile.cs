using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableTile : SelectableTile
{
    private GameObject gameObjectOnTop;

    public bool TryPlace(GameObject prefab)
    {
        if (gameObjectOnTop != null) return false;
        var instantiatedGameObject = Instantiate(prefab, transform.position, transform.rotation, transform);
        gameObjectOnTop = instantiatedGameObject;
        return true;
    }
}