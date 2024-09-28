using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Map Properties", menuName = "Map Properties", order = 51)]
public class MapProperties : ScriptableObject
{
    [Header("Map")]
    [SerializeField]
    private GameObject mapPrefab;

    [Header("Enemies")]
    [SerializeField]
    private GameObject[] enemyPrefabs;

    [SerializeField]
    private float enemySpawnIntervalSeconds = 1f;

    [SerializeField]
    private AudioClip music;

    public GameObject MapPrefab => mapPrefab;

    public GameObject[] EnemyPrefabs => enemyPrefabs;
    public float EnemySpawnIntervalSeconds => enemySpawnIntervalSeconds;
    public AudioClip Music => music;
}
