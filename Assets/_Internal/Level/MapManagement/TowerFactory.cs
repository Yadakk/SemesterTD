using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TowerFactory
{
    public static void Create(GameObject towerPrefab, Transform tile)
    {
        GameObject tower = Object.Instantiate(towerPrefab, tile);

        tower.transform.localScale = tower.transform.localScale.InverseScale(tile.localScale);

        var towerRenderer = tower.GetComponent<Renderer>();
        var tileCollider = tile.GetComponent<Collider>();

        tower.transform.position = towerRenderer.bounds.GetPositionOnTop(tileCollider.bounds);
    }
}
