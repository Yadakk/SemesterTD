using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TowerFactory
{
    public static void Create(GameObject towerPrefab, GameObject healthBarPrefab, Transform tile)
    {
        GameObject tower = Object.Instantiate(towerPrefab, tile);

        tower.transform.localScale = tower.transform.localScale.InverseScale(tile.lossyScale);

        Bounds towerBounds = tower.CalculateBounds();
        Bounds tileBounds = tile.gameObject.CalculateBounds();

        //tower.transform.position = towerBounds.GetPositionOnTop(tileBounds);

        tower.AddComponent<MonoHealth>();
        tower.AddComponent<HealthBar>().HealthSliderPrefab = healthBarPrefab;
    }
}
