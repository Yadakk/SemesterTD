using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class BoundsCalculatorExtension
{
    public static Bounds CalculateBounds(this GameObject go)
    {
        bool boundsSetFlag = false;
        Bounds combinedBounds = new();

        Bounds[] boundsArray = go.GetComponentsInChildren<Renderer>().
            Select(renderer => renderer.bounds).ToArray();

        boundsArray = boundsArray.Concat(
            go.GetComponentsInChildren<Collider>().
            Where(collider => !collider.isTrigger).
            Select(collider => collider.bounds)).ToArray();

        foreach (Bounds bounds in boundsArray)
        {
            if (!boundsSetFlag)
            {
                combinedBounds = bounds;
                boundsSetFlag = true;
            }

            combinedBounds.Encapsulate(bounds);
        }

        return combinedBounds;
    }
}
