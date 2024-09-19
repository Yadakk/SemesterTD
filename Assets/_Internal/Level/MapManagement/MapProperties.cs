using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Map Properties", menuName = "Map Properties", order = 51)]
public class MapProperties : ScriptableObject
{
    [SerializeField]
    private float enemySpawnIntervalSeconds = 1f;

    [SerializeField]
    private GameObject enemyTestPrefab;

    public float EnemySpawnIntervalSeconds => enemySpawnIntervalSeconds;

    public GameObject EnemyTestPrefab => enemyTestPrefab;
}
