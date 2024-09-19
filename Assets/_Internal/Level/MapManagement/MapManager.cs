using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private GameObject towerPrefab;

    public void SelectMap(GameObject prefab)
    {
        GameObject map = Instantiate(prefab, transform);
        var dataExtractor = map.GetComponentInChildren<MapDataExtractor>();
        var mapData = dataExtractor.ExtractData();

        var mapPropertiesContainer = map.GetComponentInChildren<MapPropertiesContainer>();

        StartEnemySpawnRoutine(
            mapData.enemySourceTiles, 
            mapPropertiesContainer.Properties.EnemyTestPrefab,
            mapPropertiesContainer.Properties.EnemySpawnIntervalSeconds
            );

        SetupTowers(towerPrefab, mapData.towerTiles);
    }

    private void StartEnemySpawnRoutine(
        List<MapTile> enemySourceTiles,
        GameObject enemyPrefab, float enemySpawnIntervalSeconds)
    {
        StartCoroutine(Routine());

        IEnumerator Routine()
        {
            while (true)
            {
                EnemyFactory.Create(enemyPrefab, enemySourceTiles[Random.Range(0, enemySourceTiles.Count)].transform);

                yield return new WaitForSeconds(enemySpawnIntervalSeconds);
            }
        }
    }

    private void SetupTowers(GameObject towerPrefab, List<MapTile> towerTiles)
    {
        foreach(var towerTile in towerTiles)
        {
            TowerFactory.Create(towerPrefab, towerTile.transform);
        }
    }
}