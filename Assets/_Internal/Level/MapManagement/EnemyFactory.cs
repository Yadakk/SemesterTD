using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyFactory
{
    public static void Create(GameObject enemyPrefab, Transform startingTile)
    {
        GameObject enemy = Object.Instantiate(enemyPrefab, startingTile.parent);
        var enemyMovement = enemy.GetComponent<EnemyMovement>();
        enemyMovement.SetCurrentNode(startingTile.GetComponent<UnitPathNode>());
    }
}