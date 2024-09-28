using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyFactory
{
    public static void Create(GameObject enemyPrefab, GameObject healthBarPrefab, Transform startingTile)
    {
        GameObject enemy = Object.Instantiate(enemyPrefab, startingTile.parent);
        var enemyMovement = enemy.AddComponent<EnemyMovement>();
        enemy.AddComponent<SphereCollider>();
        enemy.AddComponent<MonoHealth>();
        enemy.AddComponent<HealthBar>().HealthSliderPrefab = healthBarPrefab;
        enemy.AddComponent<EnemyRewards>();

        enemyMovement.SetCurrentNode(startingTile.GetComponent<UnitPathNode>());
    }
}