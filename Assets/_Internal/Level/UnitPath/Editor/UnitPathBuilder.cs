using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnitPathBuilder
{
    public static UnitPathNode AddNode(GameObject tile)
    {
        return tile.AddComponent<UnitPathNode>();
    }

    public static void RemoveNode(UnitPathNode node)
    {
        Object.DestroyImmediate(node);
    }
}